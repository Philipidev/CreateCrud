using System.Reflection;
using System.Text;

string NomeEntidade = "RegistroCampoTeste";
string DiretorioController = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI\Controllers";
string DiretorioEntidade = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.DominioEntityFramework\Entidades";
string DiretorioModel = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI\Models";
string DiretorioDtos = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Dtos";
string DiretorioExecutores = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Executores";
string DiretorioRepositorios = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.Infraestrutura\Repositorios";
string DiretorioInterfaceRepositorioAplicacao = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\RepositoriosEntityFramework";
string DiretorioRequisicao = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Requisicoes";
string DiretorioResultado = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Resultados";
string DiretorioRepositorioInfraestrutura = @"C:\Users\phili\source\repos\InspecaoWebAPI\InspecaoWebAPI.InfraestruturaEntityFramework\BancoDados\RepositoriosEntityFramework";



var assemblyPath = @"path_to_your_assembly.dll"; // Replace with your DLL path
Assembly assembly = Assembly.LoadFrom(assemblyPath);

Type entityType = assembly.GetType("InspecaoWebAPI.DominioEntityFramework.Entidades.StatusRecomendacao");

Console.WriteLine(GenerateDTO(entityType));


string GenerateInterfaceRepositorioAplicacao(string entityName, string namespaceName)
{
    StringBuilder sb = new StringBuilder();

    // Namespace
    sb.AppendFormat("using {0}.DominioEntityFramework.Entidades;\n", namespaceName);
    sb.AppendLine("using System;");
    sb.AppendLine("using System.Collections.Generic;");
    sb.AppendLine("using System.Linq.Expressions;\n");

    sb.AppendFormat("namespace {0}.Aplicacao.RepositoriosEntityFramework\n", namespaceName);
    sb.AppendLine("{");

    // Interface definition
    sb.AppendFormat("    public interface I{0}Repositorio\n", entityName);
    sb.AppendLine("    {");

    // Methods
    sb.AppendFormat("        {0} ObterPorId(params object[] ids);\n\n", entityName);

    sb.AppendFormat("        IQueryable<{0}> Listar(Expression<Func<{0}, bool>>? predicate = null, bool Tracking = false);\n\n", entityName);

    sb.AppendFormat("        IQueryable<{0}> ListarIgnorandoFiltros(Expression<Func<{0}, bool>>? predicate = null, bool Tracking = false);\n\n", entityName);

    sb.AppendFormat("        {0} Inserir({0} model);\n\n", entityName);

    sb.AppendFormat("        int Editar({0} model);\n\n", entityName);

    sb.AppendFormat("        int Editar({0} model, params Expression<Func<{0}, object>>[] properties);\n\n", entityName);

    sb.AppendFormat("        int Deletar({0} model);\n\n", entityName);

    sb.AppendLine("        int Deletar(params object[] ids);\n");

    sb.AppendFormat("        int EditarMultiplos(IEnumerable<{0}> models, params Expression<Func<{0}, object>>[] properties);\n\n", entityName);

    sb.AppendFormat("        int DeletarMultiplos(IEnumerable<{0}> models);\n\n", entityName);

    sb.AppendFormat("        int InserirMultiplos(IEnumerable<{0}> models);\n", entityName);

    // End interface and namespace
    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GenerateRepositorioInfraestrutura(string entityName, string namespaceBase)
{
    StringBuilder sb = new StringBuilder();

    sb.AppendLine($"using {namespaceBase}.Aplicacao.RepositoriosEntityFramework;");
    sb.AppendLine($"using {namespaceBase}.DominioEntityFramework.Entidades;");
    sb.AppendLine($"using Sysdam.Database.DatabaseConnection;");
    sb.AppendLine($"using System.Linq.Expressions;\n");

    sb.AppendLine($"namespace {namespaceBase}.InfraestruturaEntityFramework.BancoDados.RepositoriosEntityFramework");
    sb.AppendLine("{");
    sb.AppendFormat("    public class {0}Repositorio : I{0}Repositorio\n", entityName);
    sb.AppendLine("    {");
    sb.AppendFormat("        private readonly IDatabaseConnection<{0}> databaseConnection;\n\n", entityName);

    sb.AppendFormat("        public {0}Repositorio(IDatabaseConnection<{0}> databaseConnection)\n", entityName);
    sb.AppendLine("        {");
    sb.AppendLine("            this.databaseConnection = databaseConnection;");
    sb.AppendLine("        }\n");

    // Generate methods
    sb.AppendFormat("        public {0} ObterPorId(params object[] ids) =>\n", entityName);
    sb.AppendLine("             databaseConnection.ObterPorId(ids);\n");

    sb.AppendFormat("        public IQueryable<{0}> Listar(Expression<Func<{0}, bool>>? predicate = null, bool Tracking = false) =>\n", entityName);
    sb.AppendLine("              databaseConnection.Listar(predicate, Tracking);\n");

    // ListarIgnorandoFiltros
    sb.AppendFormat("        public IQueryable<{0}> ListarIgnorandoFiltros(Expression<Func<{0}, bool>>? predicate = null, bool Tracking = false) =>\n", entityName);
    sb.AppendLine("              databaseConnection.ListarIgnorandoFiltros(predicate, Tracking);\n");

    // Inserir
    sb.AppendFormat("        public {0} Inserir({0} model) =>\n", entityName);
    sb.AppendLine("             databaseConnection.Inserir(model);\n");

    // Editar
    sb.AppendFormat("        public int Editar({0} model) =>\n", entityName);
    sb.AppendLine("            databaseConnection.Editar(model);\n");

    sb.AppendFormat("        public int Editar({0} model, Expression<Func<{0}, object>>[] properties) =>\n", entityName);
    sb.AppendLine("            databaseConnection.Editar(model, properties);\n");

    // Deletar
    sb.AppendFormat("        public int Deletar({0} model) =>\n", entityName);
    sb.AppendLine("            databaseConnection.Excluir(model);\n");

    sb.AppendFormat("        public int Deletar(params object[] ids) =>\n");
    sb.AppendLine("            databaseConnection.Excluir(ids);\n");

    // EditarMultiplos
    sb.AppendFormat("        public int EditarMultiplos(IEnumerable<{0}> models, Expression<Func<{0}, object>>[]? properties = null) =>\n", entityName);
    sb.AppendLine("            databaseConnection.EditarMultiplos(models, properties);\n");

    // DeletarMultiplos
    sb.AppendFormat("        public int DeletarMultiplos(IEnumerable<{0}> models) =>\n", entityName);
    sb.AppendLine("            databaseConnection.DeletarMultiplos(models);\n");

    // InserirMultiplos
    sb.AppendFormat("        public int InserirMultiplos(IEnumerable<{0}> models) =>\n", entityName);
    sb.AppendLine("            databaseConnection.InserirMultiplos(models);\n");

    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GenerateExecutorToDeletar(string entityName, string namespaceBase)
{
    StringBuilder sb = new StringBuilder();

    string requisicaoName = $"Deletar{entityName}Requisicao";
    string resultadoName = $"Deletar{entityName}Resultado";
    string repositorioInterfaceName = $"I{entityName}Repositorio";
    string executorName = $"Deletar{entityName}Executor";

    sb.AppendLine($"using {namespaceBase}.Aplicacao.Dtos.{entityName}s;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.RepositoriosEntityFramework;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.Requisicoes.{entityName}s;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.Resultados.{entityName}s;");
    sb.AppendLine($"using System.Threading;");
    sb.AppendLine($"using System.Threading.Tasks;");

    sb.AppendLine($"\nnamespace {namespaceBase}.Aplicacao.Executores.{entityName}s");
    sb.AppendLine("{");
    sb.AppendLine($"    public class {executorName} : IRequestHandler<{requisicaoName}, {resultadoName}>");
    sb.AppendLine("    {");
    sb.AppendLine($"        private readonly {repositorioInterfaceName} {entityName.ToLower()}Repositorio;");
    sb.AppendLine($"        private readonly IMapper mapper;");

    sb.AppendLine($"        public {executorName}({repositorioInterfaceName} {entityName.ToLower()}Repositorio, IMapper mapper)");
    sb.AppendLine("        {");
    sb.AppendLine($"            this.{entityName.ToLower()}Repositorio = {entityName.ToLower()}Repositorio;");
    sb.AppendLine("            this.mapper = mapper;");
    sb.AppendLine("        }");

    sb.AppendLine($"        public Task<{resultadoName}> Handle({requisicaoName} request, CancellationToken cancellationToken)");
    sb.AppendLine("        {");
    sb.AppendLine($"            var entity{entityName} = {entityName.ToLower()}Repositorio.BuscarPorId(request.Id);");
    sb.AppendLine($"            if (entity{entityName} == null)");
    sb.AppendLine("            {");
    sb.AppendLine($"                return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("                {");
    sb.AppendLine($"                    IsSuccess = false,");
    sb.AppendLine($"                    Message = \"{entityName} não encontrada.\"");
    sb.AppendLine("                });");
    sb.AppendLine("            }");

    sb.AppendLine($"            {entityName.ToLower()}Repositorio.Deletar(entity{entityName});");

    sb.AppendLine($"            return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("            {");
    sb.AppendLine($"                IsSuccess = true,");
    sb.AppendLine($"                Message = \"{entityName} deletada com sucesso.\"");
    sb.AppendLine("            });");
    sb.AppendLine("        }");
    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GenerateExecutorToEditar(string entityName, string namespaceBase)
{
    StringBuilder sb = new StringBuilder();

    string requisicaoName = $"Editar{entityName}Requisicao";
    string resultadoName = $"Editar{entityName}Resultado";
    string repositorioInterfaceName = $"I{entityName}Repositorio";
    string executorName = $"Editar{entityName}Executor";

    sb.AppendLine($"using {namespaceBase}.Aplicacao.Dtos.{entityName}s;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.RepositoriosEntityFramework;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.Requisicoes.{entityName}s;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.Resultados.{entityName}s;");
    sb.AppendLine($"using System.Threading;");
    sb.AppendLine($"using System.Threading.Tasks;");

    sb.AppendLine($"\nnamespace {namespaceBase}.Aplicacao.Executores.{entityName}s");
    sb.AppendLine("{");
    sb.AppendLine($"    public class {executorName} : IRequestHandler<{requisicaoName}, {resultadoName}>");
    sb.AppendLine("    {");
    sb.AppendLine($"        private readonly {repositorioInterfaceName} {entityName.ToLower()}Repositorio;");
    sb.AppendLine($"        private readonly IMapper mapper;");

    sb.AppendLine($"        public {executorName}({repositorioInterfaceName} {entityName.ToLower()}Repositorio, IMapper mapper)");
    sb.AppendLine("        {");
    sb.AppendLine($"            this.{entityName.ToLower()}Repositorio = {entityName.ToLower()}Repositorio;");
    sb.AppendLine("            this.mapper = mapper;");
    sb.AppendLine("        }");

    sb.AppendLine($"        public Task<{resultadoName}> Handle({requisicaoName} request, CancellationToken cancellationToken)");
    sb.AppendLine("        {");
    sb.AppendLine($"            var entity{entityName} = {entityName.ToLower()}Repositorio.BuscarPorId(request.Id);");
    sb.AppendLine($"            if (entity{entityName} == null)");
    sb.AppendLine("            {");
    sb.AppendLine($"                return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("                {");
    sb.AppendLine($"                    IsSuccess = false,");
    sb.AppendLine($"                    Message = \"{entityName} não encontrada.\"");
    sb.AppendLine("                });");
    sb.AppendLine("            }");

    sb.AppendLine($"            mapper.Map(request, entity{entityName});");
    sb.AppendLine($"            {entityName.ToLower()}Repositorio.Atualizar(entity{entityName});");

    sb.AppendLine($"            return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("            {");
    sb.AppendLine($"                IsSuccess = true,");
    sb.AppendLine($"                Message = \"{entityName} editada com sucesso.\"");
    sb.AppendLine("            });");
    sb.AppendLine("        }");
    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GenerateExecutorToInsert(string entityName, string namespaceBase)
{
    StringBuilder sb = new StringBuilder();

    string requisicaoName = $"Inserir{entityName}Requisicao";
    string resultadoName = $"Inserir{entityName}Resultado";
    string repositorioInterfaceName = $"I{entityName}Repositorio";
    string executorName = $"Inserir{entityName}Executor";

    sb.AppendLine($"using {namespaceBase}.Aplicacao.Dtos.{entityName}s;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.RepositoriosEntityFramework;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.Requisicoes.{entityName}s;");
    sb.AppendLine($"using {namespaceBase}.Aplicacao.Resultados.{entityName}s;");
    sb.AppendLine($"using System.Threading;");
    sb.AppendLine($"using System.Threading.Tasks;");

    sb.AppendLine($"\nnamespace {namespaceBase}.Aplicacao.Executores.{entityName}s");
    sb.AppendLine("{");
    sb.AppendLine($"    public class {executorName} : IRequestHandler<{requisicaoName}, {resultadoName}>");
    sb.AppendLine("    {");
    sb.AppendLine($"        private readonly {repositorioInterfaceName} {entityName.ToLower()}Repositorio;");
    sb.AppendLine($"        private readonly IMapper mapper;");

    sb.AppendLine($"        public {executorName}({repositorioInterfaceName} {entityName.ToLower()}Repositorio, IMapper mapper)");
    sb.AppendLine("        {");
    sb.AppendLine($"            this.{entityName.ToLower()}Repositorio = {entityName.ToLower()}Repositorio;");
    sb.AppendLine("            this.mapper = mapper;");
    sb.AppendLine("        }");

    sb.AppendLine($"        public Task<{resultadoName}> Handle({requisicaoName} request, CancellationToken cancellationToken)");
    sb.AppendLine("        {");
    sb.AppendLine($"            var entity{entityName} = mapper.Map<{entityName}>(request);");
    sb.AppendLine($"            {entityName.ToLower()}Repositorio.Inserir(entity{entityName});");
    sb.AppendLine($"            return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("            {");
    sb.AppendLine($"                IsSuccess = true,");
    sb.AppendLine($"                Message = \"{entityName} inserida com sucesso.\"");
    sb.AppendLine("            });");
    sb.AppendLine("        }");
    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GenerateRequisicaoAndResultadoToListarPorVariavel(string assemblyPath, string entityName, string variableName)
{
    // Carregar o assembly
    Assembly loadedAssembly = Assembly.LoadFile(assemblyPath);

    // Obter o tipo da entidade
    Type entityType = loadedAssembly.GetType(entityName);

    if (entityType == null)
    {
        throw new InvalidOperationException($"Tipo {entityName} não encontrado no assembly {assemblyPath}.");
    }

    // Verificar se a entidade tem a propriedade específica
    PropertyInfo propertyInfo = entityType.GetProperty(variableName);
    if (propertyInfo == null)
    {
        throw new InvalidOperationException($"Propriedade {variableName} não encontrada em {entityName}.");
    }

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Listar{entityName}Por{variableName}Requisicao");
    requisicaoCode.AppendLine("    {");
    requisicaoCode.AppendLine($"        public {propertyInfo.PropertyType.Name} {variableName} {{ get; set; }}");
    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Listar{entityName}Por{variableName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public List<{entityType.Name}> Itens {{ get; set; }} = new List<{entityType.Name}>();");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return requisicaoCode.ToString() + "\n\n" + resultadoCode.ToString();
}

string GenerateRequisicaoAndResultadoToDeletar(string assemblyPath, string entityName)
{
    // Carregar o assembly
    Assembly loadedAssembly = Assembly.LoadFile(assemblyPath);

    // Obter o tipo da entidade
    Type entityType = loadedAssembly.GetType(entityName);

    if (entityType == null)
    {
        throw new InvalidOperationException($"Tipo {entityName} não encontrado no assembly {assemblyPath}.");
    }

    // Identificar a chave primária da entidade
    PropertyInfo primaryKey = entityType.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id")); // Este é um suposto padrão; ajuste conforme necessário

    if (primaryKey == null)
    {
        throw new InvalidOperationException($"Não foi possível identificar a chave primária para {entityName}.");
    }

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Deletar{entityName}Requisicao");
    requisicaoCode.AppendLine("    {");
    requisicaoCode.AppendLine($"        public {primaryKey.PropertyType.Name} {primaryKey.Name} {{ get; set; }}");
    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Deletar{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public bool Sucesso {{ get; set; }}");
    resultadoCode.AppendLine($"        public string Mensagem {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return requisicaoCode.ToString() + "\n\n" + resultadoCode.ToString();
}


string GenerateRequisicaoAndResultadoToListarPorEmpreendimento(string assemblyPath, string entityName)
{
    // Carregar o assembly
    Assembly loadedAssembly = Assembly.LoadFile(assemblyPath);

    // Obter o tipo da entidade
    Type entityType = loadedAssembly.GetType(entityName);

    if (entityType == null)
    {
        throw new InvalidOperationException($"Tipo {entityName} não encontrado no assembly {assemblyPath}.");
    }

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Listar{entityName}PorEmpreendimentoRequisicao");
    requisicaoCode.AppendLine("    {");
    requisicaoCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");
    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Listar{entityName}PorEmpreendimentoResultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public bool Sucesso {{ get; set; }}");
    resultadoCode.AppendLine($"        public string Mensagem {{ get; set; }}");
    resultadoCode.AppendLine($"        public List<{entityName}DTO> Itens {{ get; set; }} = new List<{entityName}DTO>();");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return requisicaoCode.ToString() + "\n\n" + resultadoCode.ToString();
}



string GenerateRequisicaoAndResultadoToEditar(string assemblyPath, string entityName)
{
    // Carregar o assembly
    Assembly loadedAssembly = Assembly.LoadFile(assemblyPath);

    // Obter o tipo da entidade
    Type entityType = loadedAssembly.GetType(entityName);

    if (entityType == null)
    {
        throw new InvalidOperationException($"Tipo {entityName} não encontrado no assembly {assemblyPath}.");
    }

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Editar{entityName}Requisicao");
    requisicaoCode.AppendLine("    {");

    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Editar{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public bool Sucesso {{ get; set; }}");
    resultadoCode.AppendLine($"        public string Mensagem {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    foreach (PropertyInfo property in entityType.GetProperties())
    {
        // Excluir apenas a DataExclusao
        if (property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase))
        {
            continue;
        }

        string propertyType = property.PropertyType.Name;
        string propertyName = property.Name;

        // Adicionar propriedade ao código de Requisicao
        requisicaoCode.AppendLine($"        public {propertyType} {propertyName} {{ get; set; }}");
    }

    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    return requisicaoCode.ToString() + "\n\n" + resultadoCode.ToString();
}



string GenerateRequisicaoAndResultadoToInserir(string assemblyPath, string entityName)
{
    // Carregar o assembly
    Assembly loadedAssembly = Assembly.LoadFile(assemblyPath);

    // Obter o tipo da entidade
    Type entityType = loadedAssembly.GetType(entityName);

    if (entityType == null)
    {
        throw new InvalidOperationException($"Tipo {entityName} não encontrado no assembly {assemblyPath}.");
    }

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Inserir{entityName}Requisicao");
    requisicaoCode.AppendLine("    {");

    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Inserir{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    foreach (PropertyInfo property in entityType.GetProperties())
    {
        // Excluir a chave primária e a DataExclusao
        if (property.Name.Equals($"Id{entityName}", StringComparison.OrdinalIgnoreCase) || property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase))
        {
            continue;
        }

        string propertyType = property.PropertyType.Name;
        string propertyName = property.Name;

        // Adicionar propriedade ao código de Requisicao
        requisicaoCode.AppendLine($"        public {propertyType} {propertyName} {{ get; set; }}");
    }

    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    return requisicaoCode.ToString() + "\n\n" + resultadoCode.ToString();
}

string GenerateDTO(Type entityType)
{
    StringBuilder sb = new StringBuilder();

    var simpleEntityName = entityType.Name;

    sb.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Dtos");
    sb.AppendLine("{");
    sb.AppendLine($"    public class {simpleEntityName}Dto");
    sb.AppendLine("    {");

    foreach (var prop in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
        if (!prop.PropertyType.Name.Contains("ICollection"))
        {
            sb.AppendLine($"        public {prop.PropertyType.Name} {prop.Name} {{ get; set; }}");
        }
    }

    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}