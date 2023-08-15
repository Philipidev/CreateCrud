using System.Reflection;
using System.Text;

string DiretorioModel = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI\Models";
string DiretorioDtos = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Dtos";
string DiretorioExecutores = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Executores";
string DiretorioInterfaceRepositorioAplicacao = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\RepositoriosEntityFramework";
string DiretorioRequisicao = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Requisicoes";
string DiretorioResultado = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Resultados";
string DiretorioRepositorioInfraestrutura = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.InfraestruturaEntityFramework\BancoDados\RepositoriosEntityFramework";

string namespaceName = "InspecaoWebAPI";
string entityName = "TesteEntidade";
string assemblyEntidadePath = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.DominioEntityFramework\bin\Debug\net6.0\InspecaoWebAPI.DominioEntityFramework.dll";

Assembly assembly = Assembly.LoadFrom(assemblyEntidadePath);
string aaaaaa = $"InspecaoWebAPI.DominioEntityFramework.Entidades.{entityName}";
//Type entityType = assembly.GetType(entityName);
Type entityType = assembly.GetTypes().FirstOrDefault(a=>a.FullName.EndsWith(entityName));

//Dto
string dto = GenerateDTO(entityType);
string entityDirectory = Path.Combine(DiretorioDtos, $"{entityName}s");
Directory.CreateDirectory(entityDirectory);
string filePath = Path.Combine(entityDirectory, $"{entityName}Dto.cs");
File.WriteAllText(filePath, dto);

//Repositorios (Interface/Implementacao)
// Interface
string interfaceRepositorio = GenerateInterfaceRepositorioAplicacao(entityName, namespaceName);
string interfaceRepositorioDirectory = Path.Combine(DiretorioInterfaceRepositorioAplicacao, $"{entityName}s");
Directory.CreateDirectory(interfaceRepositorioDirectory);
string interfaceRepositorioFilePath = Path.Combine(interfaceRepositorioDirectory, $"I{entityName}Repositorio.cs");
File.WriteAllText(interfaceRepositorioFilePath, interfaceRepositorio);

// Implementacao
string implementacaoRepositorio = GenerateRepositorioInfraestrutura(entityName, namespaceName);
string implementacaoRepositorioDirectory = Path.Combine(DiretorioRepositorioInfraestrutura, $"{entityName}s");
Directory.CreateDirectory(implementacaoRepositorioDirectory);
string implementacaoRepositorioFilePath = Path.Combine(implementacaoRepositorioDirectory, $"{entityName}Repositorio.cs");
File.WriteAllText(implementacaoRepositorioFilePath, implementacaoRepositorio);

//CRUD: Obter (Executor/Requisicao/Resultado/Input/Output)
// Executor
string executorCode = GenerateExecutorToObter(entityName, namespaceName);
string executorDirectory = Path.Combine(DiretorioExecutores, $"{entityName}s");
Directory.CreateDirectory(executorDirectory);
string executorFilePath = Path.Combine(executorDirectory, $"Obter{entityName}Executor.cs");
File.WriteAllText(executorFilePath, executorCode);

// Requisicao
string requisicaoCode = GenerateRequisicaoToObter(entityName);
string requisicaoDirectory = Path.Combine(DiretorioRequisicao, $"{entityName}s");
Directory.CreateDirectory(requisicaoDirectory);
string requisicaoFilePath = Path.Combine(requisicaoDirectory, $"Obter{entityName}Requisicao.cs");
File.WriteAllText(requisicaoFilePath, requisicaoCode);

// Resultado
string resultadoCode = GenerateResultadoToObter(entityName);
string resultadoDirectory = Path.Combine(DiretorioResultado, $"{entityName}s");
Directory.CreateDirectory(resultadoDirectory);
string resultadoFilePath = Path.Combine(resultadoDirectory, $"Obter{entityName}Resultado.cs");
File.WriteAllText(resultadoFilePath, resultadoCode);

// Input
string inputCode = GenerateInputToObter(entityName);
string inputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(inputDirectory);
string inputFilePath = Path.Combine(inputDirectory, $"Obter{entityName}Input.cs");
File.WriteAllText(inputFilePath, inputCode);

// Output
string outputCode = GenerateOutputToObter(entityName);
string outputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(outputDirectory);
string outputFilePath = Path.Combine(outputDirectory, $"Obter{entityName}Output.cs");
File.WriteAllText(outputFilePath, outputCode);

//CRUD: Inserir (Executor/Requisicao/Resultado/Input/Output)
// Executor
executorCode = GenerateExecutorToInsert(entityName, namespaceName);
executorDirectory = Path.Combine(DiretorioExecutores, $"{entityName}s");
Directory.CreateDirectory(executorDirectory);
executorFilePath = Path.Combine(executorDirectory, $"Inserir{entityName}Executor.cs");
File.WriteAllText(executorFilePath, executorCode);

// Requisicao
requisicaoCode = GenerateRequisicaoToInserir(entityType, entityName);
requisicaoDirectory = Path.Combine(DiretorioRequisicao, $"{entityName}s");
Directory.CreateDirectory(requisicaoDirectory);
requisicaoFilePath = Path.Combine(requisicaoDirectory, $"Inserir{entityName}Requisicao.cs");
File.WriteAllText(requisicaoFilePath, requisicaoCode);

// Resultado
resultadoCode = GenerateResultadoToInserir(entityName);
resultadoDirectory = Path.Combine(DiretorioResultado, $"{entityName}s");
Directory.CreateDirectory(resultadoDirectory);
resultadoFilePath = Path.Combine(resultadoDirectory, $"Inserir{entityName}Resultado.cs");
File.WriteAllText(resultadoFilePath, resultadoCode);

// Input
inputCode = GenerateInputToInserir(entityType,entityName);
inputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(inputDirectory);
inputFilePath = Path.Combine(inputDirectory, $"Inserir{entityName}Input.cs");
File.WriteAllText(inputFilePath, inputCode);

// Output
outputCode = GenerateOutputToInserir(entityName);
outputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(outputDirectory);
outputFilePath = Path.Combine(outputDirectory, $"Inserir{entityName}Output.cs");
File.WriteAllText(outputFilePath, outputCode);

//CRUD: Editar (Executor/Requisicao/Resultado/Input/Output)
// Executor
executorCode = GenerateExecutorToEditar(entityName, namespaceName);
executorDirectory = Path.Combine(DiretorioExecutores, $"{entityName}s");
Directory.CreateDirectory(executorDirectory);
executorFilePath = Path.Combine(executorDirectory, $"Editar{entityName}Executor.cs");
File.WriteAllText(executorFilePath, executorCode);

// Requisicao
requisicaoCode = GenerateRequisicaoToEditar(entityType, entityName);
requisicaoDirectory = Path.Combine(DiretorioRequisicao, $"{entityName}s");
Directory.CreateDirectory(requisicaoDirectory);
requisicaoFilePath = Path.Combine(requisicaoDirectory, $"Editar{entityName}Requisicao.cs");
File.WriteAllText(requisicaoFilePath, requisicaoCode);

// Resultado
resultadoCode = GenerateResultadoToEditar(entityName);
resultadoDirectory = Path.Combine(DiretorioResultado, $"{entityName}s");
Directory.CreateDirectory(resultadoDirectory);
resultadoFilePath = Path.Combine(resultadoDirectory, $"Editar{entityName}Resultado.cs");
File.WriteAllText(resultadoFilePath, resultadoCode);

// Input
inputCode = GenerateInputToEditar(entityType, entityName);
inputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(inputDirectory);
inputFilePath = Path.Combine(inputDirectory, $"Editar{entityName}Input.cs");
File.WriteAllText(inputFilePath, inputCode);

// Output
outputCode = GenerateOutputToEditar(entityName);
outputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(outputDirectory);
outputFilePath = Path.Combine(outputDirectory, $"Editar{entityName}Output.cs");
File.WriteAllText(outputFilePath, outputCode);

//CRUD: Deletar (Executor/Requisicao/Resultado/Input/Output)
// Executor
executorCode = GenerateExecutorToDeletar(entityName, namespaceName);
executorDirectory = Path.Combine(DiretorioExecutores, $"{entityName}s");
Directory.CreateDirectory(executorDirectory);
executorFilePath = Path.Combine(executorDirectory, $"Deletar{entityName}Executor.cs");
File.WriteAllText(executorFilePath, executorCode);

// Requisicao
requisicaoCode = GenerateRequisicaoToDeletar(entityType, entityName);
requisicaoDirectory = Path.Combine(DiretorioRequisicao, $"{entityName}s");
Directory.CreateDirectory(requisicaoDirectory);
requisicaoFilePath = Path.Combine(requisicaoDirectory, $"Deletar{entityName}Requisicao.cs");
File.WriteAllText(requisicaoFilePath, requisicaoCode);

// Resultado
resultadoCode = GenerateResultadoToDeletar(entityName);
resultadoDirectory = Path.Combine(DiretorioResultado, $"{entityName}s");
Directory.CreateDirectory(resultadoDirectory);
resultadoFilePath = Path.Combine(resultadoDirectory, $"Deletar{entityName}Resultado.cs");
File.WriteAllText(resultadoFilePath, resultadoCode);

// Input
inputCode = GenerateInputToDeletar(entityType, entityName);
inputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(inputDirectory);
inputFilePath = Path.Combine(inputDirectory, $"Deletar{entityName}Input.cs");
File.WriteAllText(inputFilePath, inputCode);

// Output
outputCode = GenerateOutputToDeletar(entityName);
outputDirectory = Path.Combine(DiretorioModel, $"{entityName}s");
Directory.CreateDirectory(outputDirectory);
outputFilePath = Path.Combine(outputDirectory, $"Deletar{entityName}Output.cs");
File.WriteAllText(outputFilePath, outputCode);


string GenerateController(string entityName, string namespaceName)
{
    StringBuilder sb = new StringBuilder();

    // Using Directives
    sb.AppendLine("using " + namespaceName + ".Aplicacao.Requisicoes." + entityName + ";");
    sb.AppendLine("using " + namespaceName + ".Aplicacao.Resultados." + entityName + ";");
    sb.AppendLine("using " + namespaceName + ".Extensions;");
    sb.AppendLine("using " + namespaceName + ".Models." + entityName + ";");
    sb.AppendLine("using Microsoft.AspNetCore.Http;");
    sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
    sb.AppendLine("using System.Threading;");
    sb.AppendLine("using System.Threading.Tasks;\n");

    // Namespace & Controller
    sb.AppendLine($"namespace {namespaceName}.Controllers");
    sb.AppendLine("{");

    sb.AppendFormat("    public class {0}Controller : ApiController\n", entityName);
    sb.AppendLine("    {");

    string[] actions = { 
        //"Listar",
        "Obter", 
        "Excluir", 
        "Inserir",
        "Editar"
    };

    foreach (var action in actions)
    {
        string httpVerb;
        switch (action)
        {
            case "Listar": httpVerb = "HttpGet"; break;
            case "Obter": httpVerb = "HttpGet"; break;
            case "Excluir": httpVerb = "HttpDelete"; break;
            case "Inserir": httpVerb = "HttpPost"; break;
            default: httpVerb = "HttpPut"; break;
        }

        sb.AppendFormat("        [{0}(\"api/[controller]/{1}{2}\")]\n", httpVerb, action, entityName);
        sb.AppendFormat("        [ProducesResponseType(typeof({0}{1}Output), StatusCodes.Status200OK)]\n", action, entityName);
        sb.AppendFormat("        public async Task<ObjectResult> {0}{1}({0}{1}Input input, CancellationToken cancellationToken)\n", action, entityName);
        sb.AppendLine("        {");

        sb.AppendFormat("            {0}{1}Requisicao requisicao = new {0}{1}Requisicao()\n", action, entityName);
        sb.AppendLine("            {");
        sb.AppendFormat("                Id{0} = input.Id{0},\n", entityName);
        sb.AppendLine("                IdUsuario = User.Identity.ObterIdUsuario(),");
        sb.AppendLine("            };");
        sb.AppendLine();

        sb.AppendFormat("            {0}{1}Resultado resultado = await Mediator.Send(requisicao, cancellationToken);\n\n", action, entityName);

        sb.AppendFormat("            {0}{1}Output output = new {0}{1}Output()\n", action, entityName);
        sb.AppendLine("            {");
        sb.AppendFormat("                {0} = resultado.{0}\n", entityName);
        sb.AppendLine("            };");
        sb.AppendLine();

        sb.AppendLine("            return new ObjectResult(output)");
        sb.AppendLine("            {");
        sb.AppendLine("                StatusCode = StatusCodes.Status200OK,");
        sb.AppendLine("            };");
        sb.AppendLine("        }\n");
    }

    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GenerateExecutorToObter(string entityName, string namespaceName)
{
    StringBuilder sb = new StringBuilder();

    // Using Directives
    sb.AppendLine($"using {namespaceName}.Aplicacao.Dtos.{entityName}s;");
    sb.AppendLine($"using {namespaceName}.Aplicacao.RepositoriosEntityFramework;");
    sb.AppendLine($"using {namespaceName}.Aplicacao.Requisicoes.{entityName}s;");
    sb.AppendLine($"using {namespaceName}.Aplicacao.Resultados.{entityName}s;");
    sb.AppendLine("using System.Threading;");
    sb.AppendLine("using System.Threading.Tasks;\n");

    // Namespace
    sb.AppendLine($"namespace {namespaceName}.Aplicacao.Executores.{entityName}s");
    sb.AppendLine("{");

    // Class definition
    sb.AppendFormat("    public class Obter{0}Executor : IRequestHandler<Obter{0}Requisicao, Obter{0}Resultado>\n", entityName);
    sb.AppendLine("    {");
    sb.AppendFormat("        private readonly I{0}Repositorio {1}Repositorio;\n", entityName, entityName.ToLower());
    sb.AppendLine("        private readonly IMapper mapper;\n");

    // Constructor
    sb.AppendFormat("        public Obter{0}Executor(I{0}Repositorio {1}Repositorio, IMapper mapper)\n", entityName, entityName.ToLower());
    sb.AppendLine("        {");
    sb.AppendFormat("            this.{0}Repositorio = {0}Repositorio;\n", entityName.ToLower());
    sb.AppendLine("            this.mapper = mapper;");
    sb.AppendLine("        }\n");

    // Handle method
    sb.AppendFormat("        public Task<Obter{0}Resultado> Handle(Obter{0}Requisicao request, CancellationToken cancellationToken)\n", entityName);
    sb.AppendLine("        {");
    sb.AppendFormat("            var {0} = {1}Repositorio.ObterPorId(request.Id);\n", entityName.ToLower(), entityName.ToLower());
    sb.AppendFormat("            var {0}Dto = mapper.Map<{0}Dto>({1});\n", entityName, entityName.ToLower());

    sb.AppendFormat("            return Task.FromResult(new Obter{0}Resultado()\n", entityName);
    sb.AppendLine("            {");
    sb.AppendFormat("                {0} = {1}Dto\n", entityName, entityName.ToLower());
    sb.AppendLine("            });");
    sb.AppendLine("        }");

    // End Class and Namespace
    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

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

string GenerateRequisicaoToObter(string entidadeNome)
{
    StringBuilder requisicaoCode = new StringBuilder();

    // Generate Requisicao Code
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entidadeNome}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendFormat("    public class Obter{0}Requisicao\n", entidadeNome);
    requisicaoCode.AppendLine("    {");
    requisicaoCode.AppendLine($"       public int Id{entidadeNome} {{ get; set; }}");
    requisicaoCode.AppendLine("        public int IdUsuario { get; set; }");
    requisicaoCode.AppendLine("        public int IdEmpreendimento { get; set; }");
    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    return requisicaoCode.ToString();
}

string GenerateInputToObter(string entidadeNome)
{
    StringBuilder inputCode = new StringBuilder();

    // Generate Requisicao Code
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    inputCode.AppendLine("{");
    inputCode.AppendFormat("    public class Obter{0}Input\n", entidadeNome);
    inputCode.AppendLine("    {");
    inputCode.AppendLine($"       public int Id{entidadeNome} {{ get; set; }}");
    inputCode.AppendLine("        public int IdEmpreendimento { get; set; }");
    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return inputCode.ToString();
}

string GenerateResultadoToObter(string entidadeNome)
{
    StringBuilder resultadoCode = new StringBuilder();

    // Generate Resultado Code
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados.{entidadeNome}s");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendFormat("    public class Obter{0}Resultado\n", entidadeNome);
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public {entidadeNome}Dto {entidadeNome} {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return resultadoCode.ToString();
}

string GenerateOutputToObter(string entidadeNome)
{
    StringBuilder outputCode = new StringBuilder();

    // Generate Output Code
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    outputCode.AppendLine("{");
    outputCode.AppendFormat("    public class Obter{0}Output\n", entidadeNome);
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public {entidadeNome}Dto {entidadeNome} {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
}

string GenerateRequisicaoToDeletar(Type entityType, string entityName)
{
    // Identificar a chave primária da entidade
    PropertyInfo primaryKey = entityType.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id")); // Este é um suposto padrão; ajuste conforme necessário

    if (primaryKey == null)
    {
        throw new InvalidOperationException($"Não foi possível identificar a chave primária para {entityName}.");
    }

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entityName}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Deletar{entityName}Requisicao");
    requisicaoCode.AppendLine("    {");
    requisicaoCode.AppendLine($"        public {primaryKey.PropertyType.Name.ToLower().Replace("32", "")} {primaryKey.Name} {{ get; set; }}");
    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    return requisicaoCode.ToString();
}


string GenerateInputToDeletar(Type entityType, string entityName)
{
    // Identificar a chave primária da entidade
    PropertyInfo primaryKey = entityType.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id")); // Este é um suposto padrão; ajuste conforme necessário

    if (primaryKey == null)
    {
        throw new InvalidOperationException($"Não foi possível identificar a chave primária para {entityName}.");
    }

    // Construir código para Input
    StringBuilder inputCode = new StringBuilder();
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    inputCode.AppendLine("{");
    inputCode.AppendLine($"    public class Deletar{entityName}Input");
    inputCode.AppendLine("    {");
    inputCode.AppendLine($"        public {primaryKey.PropertyType.Name.ToLower().Replace("32", "")} {primaryKey.Name} {{ get; set; }}");
    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return inputCode.ToString();
}
string GenerateOutputToDeletar(string entityName)
{
    // Construir código para Output
    StringBuilder outputCode = new StringBuilder();
    outputCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Outputs");
    outputCode.AppendLine("{");
    outputCode.AppendLine($"    public class Deletar{entityName}Output");
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public bool Sucesso {{ get; set; }}");
    outputCode.AppendLine($"        public string Mensagem {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
}


string GenerateResultadoToDeletar(string entityName)
{
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

    return resultadoCode.ToString();
}

string GenerateRequisicaoToEditar(Type entityType, string entityName)
{
    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entityName}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Editar{entityName}Requisicao");
    requisicaoCode.AppendLine("    {");

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

    return requisicaoCode.ToString();
}



string GenerateInputToEditar(Type entityType, string entityName)
{
    // Construir código para Input
    StringBuilder inputCode = new StringBuilder();
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    inputCode.AppendLine("{");
    inputCode.AppendLine($"    public class Editar{entityName}Input");
    inputCode.AppendLine("    {");

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
        inputCode.AppendLine($"        public {propertyType} {propertyName} {{ get; set; }}");
    }

    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return inputCode.ToString();
}

string GenerateResultadoToEditar(string entityName)
{
    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados.{entityName}s");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Editar{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public bool Sucesso {{ get; set; }}");
    resultadoCode.AppendLine($"        public string Mensagem {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return resultadoCode.ToString();
}

string GenerateOutputToEditar(string entityName)
{
    // Construir código para Output
    StringBuilder outputCode = new StringBuilder();
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    outputCode.AppendLine("{");
    outputCode.AppendLine($"    public class Editar{entityName}Output");
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public bool Sucesso {{ get; set; }}");
    outputCode.AppendLine($"        public string Mensagem {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
}

string GenerateRequisicaoToInserir(Type entityType, string entityName)
{
    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entityName}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Inserir{entityName}Requisicao");
    requisicaoCode.AppendLine("    {");

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

    return requisicaoCode.ToString();
}

string GenerateInputToInserir(Type entityType, string entityName)
{
    // Construir código para Input
    StringBuilder inputCode = new StringBuilder();
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    inputCode.AppendLine("{");
    inputCode.AppendLine($"    public class Inserir{entityName}Input");
    inputCode.AppendLine("    {");

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
        inputCode.AppendLine($"        public {propertyType} {propertyName} {{ get; set; }}");
    }

    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return requisicaoCode.ToString();
}

string GenerateResultadoToInserir(string entityName)
{
    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados.{entityName}s");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Inserir{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return resultadoCode.ToString();
}
string GenerateOutputToInserir(string entityName)
{
    // Construir código para Output
    StringBuilder outputCode = new StringBuilder();
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models");
    outputCode.AppendLine("{");
    outputCode.AppendLine($"    public class Inserir{entityName}Output");
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
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