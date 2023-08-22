using System.Reflection;
using System.Text;

string DiretorioModel = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI\Models";
string DiretorioDtos = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Dtos";
string DiretorioExecutores = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Executores";
string DiretorioInterfaceRepositorioAplicacao = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\RepositoriosEntityFramework";
string DiretorioRequisicao = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Requisicoes";
string DiretorioResultado = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.Aplicacao\Resultados";
string DiretorioRepositorioInfraestrutura = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.InfraestruturaEntityFramework\BancoDados\RepositoriosEntityFramework";
string DiretorioController = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI\Controllers";

string namespaceName = "InspecaoWebAPI";
string entityName = "RecomendacaoPlanoAcaoTipoCategoriaConteudo";
string assemblyEntidadePath = @"D:\Repositorios\Sysdam\InspecaoWebAPI\InspecaoWebAPI.DominioEntityFramework\bin\Debug\net6.0\InspecaoWebAPI.DominioEntityFramework.dll";

Assembly assembly = Assembly.LoadFrom(assemblyEntidadePath);
//Type entityType = assembly.GetType(entityName);
Type entityType = assembly.GetTypes().FirstOrDefault(a => a.FullName.EndsWith(entityName));

if (entityType == null)
{
    Console.WriteLine("Entidade não encontrada");
    Console.WriteLine("Se o arquivo existir, lembre de compilar primeiro o projeto para gerar a DLL");
    return;
}

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
inputCode = GenerateInputToInserir(entityType, entityName);
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

//Controller
string controllerCode = GenerateController(entityName, namespaceName);
string controllerDirectory = Path.Combine(DiretorioController);
Directory.CreateDirectory(controllerDirectory);
string controllerFilePath = Path.Combine(controllerDirectory, $"{entityName}Controller.cs");
File.WriteAllText(controllerFilePath, controllerCode);

string GenerateController(string entityName, string namespaceName)
{
    StringBuilder sb = new StringBuilder();

    // Using Directives
    sb.AppendLine($"using {namespaceName}.Aplicacao.Requisicoes.{entityName}s;");
    sb.AppendLine($"using {namespaceName}.Aplicacao.Resultados.{entityName}s;");
    sb.AppendLine("using " + namespaceName + ".Extensions;");
    sb.AppendLine($"using {namespaceName}.Models.{entityName}s;");
    sb.AppendLine("using Microsoft.AspNetCore.Http;");
    sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
    sb.AppendLine("using System.Threading;");
    sb.AppendLine("using System.Threading.Tasks;");
    sb.AppendLine($"using System;");
    sb.AppendLine($"using System.Collections.Generic;\n");

    // Namespace & Controller
    sb.AppendLine($"namespace {namespaceName}.Controllers");
    sb.AppendLine("{");

    sb.AppendFormat("    public class {0}Controller : ApiController\n", entityName);
    sb.AppendLine("    {");

    string[] actions = {
        //"Listar",
        "Obter",
        "Deletar",
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
            case "Deletar": httpVerb = "HttpDelete"; break;
            case "Inserir": httpVerb = "HttpPost"; break;
            case "Editar": httpVerb = "HttpPut"; break;
            default: httpVerb = "HttpPut"; break;
        }

        sb.AppendFormat("        [{0}(\"api/[controller]/{1}{2}\")]\n", httpVerb, action, entityName);
        sb.AppendFormat("        [ProducesResponseType(typeof({0}{1}Output), StatusCodes.Status200OK)]\n", action, entityName);
        if (httpVerb is "HttpGet")
            sb.AppendFormat("        public async Task<ObjectResult> {0}{1}([FromQuery]{0}{1}Input input, CancellationToken cancellationToken)\n", action, entityName);
        else
            sb.AppendFormat("        public async Task<ObjectResult> {0}{1}({0}{1}Input input, CancellationToken cancellationToken)\n", action, entityName);
        sb.AppendLine("        {");

        sb.AppendFormat("            {0}{1}Requisicao requisicao = new {0}{1}Requisicao()\n", action, entityName);
        sb.AppendLine("            {");
        if (action is "Obter" or "Editar" or "Deletar")
            sb.AppendFormat("                Id{0} = input.Id{0},\n", entityName);
        if (action is "Editar" or "Inserir")
        {
            PropertyInfo primaryKey = entityType.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id")); // Este é um suposto padrão; ajuste conforme necessário

            foreach (PropertyInfo property in entityType.GetProperties())
            {
                if (primaryKey.Name == property.Name)
                    continue;

                // Excluir apenas a DataExclusao
                if (property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase)
                   || property.PropertyType.Name.Contains("ICollection")
                    || property.PropertyType.Namespace.Contains("InspecaoWebAPI")
                   )
                {
                    continue;
                }

                string propertyName = property.Name;

                if (propertyName == "IdEmpreendimento" || propertyName == "IdUsuario")
                    continue;

                // Adicionar propriedade ao código de Requisicao
                sb.AppendLine($"                {propertyName} = input.{propertyName},");
            }
        }
        sb.AppendLine("                IdUsuario = User.Identity.ObterIdUsuario(),");
        sb.AppendLine("                IdEmpreendimento = input.IdEmpreendimento,");
        sb.AppendLine("            };");
        sb.AppendLine();

        sb.AppendFormat("            {0}{1}Resultado resultado = await Mediator.Send(requisicao, cancellationToken);\n\n", action, entityName);

        sb.AppendFormat("            {0}{1}Output output = new {0}{1}Output()\n", action, entityName);
        sb.AppendLine("            {");
        if (action is "Obter" or "Inserir")
            sb.AppendFormat("                {0} = resultado.{0},\n", entityName);
        if (action is "Editar" or "Deletar")
            sb.AppendFormat("                Id{0} = resultado.Id{0},\n", entityName);
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
    sb.AppendLine("using System;");
    sb.AppendLine("using System.Threading.Tasks;");
    sb.AppendLine("using System.Collections.Generic;\n");

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
    sb.AppendFormat("            var {0} = {1}Repositorio.ObterPorId(request.Id{2});\n", entityName.ToLower(), entityName.ToLower(), entityName);
    sb.AppendFormat("            var {0}Dto = mapper.Map<{0}Dto>({1});\n", entityName, entityName.ToLower());

    sb.AppendFormat("            return Task.FromResult(new Obter{0}Resultado()\n", entityName);
    sb.AppendLine("            {");
    sb.AppendFormat("                {0} = {0}Dto\n", entityName);
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
    sb.AppendLine("using System.Linq.Expressions;");

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
    sb.AppendLine("using System;");
    sb.AppendLine("using System.Collections.Generic;");
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
    sb.AppendLine("using System;");
    sb.AppendLine($"using System.Threading.Tasks;");
    sb.AppendLine("using InspecaoWebAPI.DominioEntityFramework.Entidades;");
    sb.AppendLine("using InspecaoWebAPI.Aplicacao.Exceptions;");
    sb.AppendLine("using System.Collections.Generic;\n");

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
    sb.AppendLine($"            var entity{entityName} = {entityName.ToLower()}Repositorio.ObterPorId(request.Id{entityName});");
    sb.AppendLine($"            if (entity{entityName} == null)");
    sb.AppendLine("            {");
    sb.AppendLine($"                throw new EntidadeNaoEncontradaException();");
    sb.AppendLine("            }");

    sb.AppendLine($"            {entityName.ToLower()}Repositorio.Deletar(entity{entityName});");

    sb.AppendLine($"            return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("            {");
    sb.AppendLine($"                Id{entityName} = request.Id{entityName},");
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
    sb.AppendLine("using System;");
    sb.AppendLine("using InspecaoWebAPI.DominioEntityFramework.Entidades;");
    sb.AppendLine($"using System.Threading.Tasks;");
    sb.AppendLine("using InspecaoWebAPI.Aplicacao.Exceptions;");
    sb.AppendLine("using System.Collections.Generic;\n");

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
    sb.AppendLine($"            var entity{entityName} = {entityName.ToLower()}Repositorio.ObterPorId(request.Id{entityName});");
    sb.AppendLine($"            if (entity{entityName} == null)");
    sb.AppendLine("            {");
    sb.AppendLine($"                throw new EntidadeNaoEncontradaException();");
    sb.AppendLine("            }");

    sb.AppendLine($"            mapper.Map(request, entity{entityName});");
    sb.AppendLine($"            {entityName.ToLower()}Repositorio.Editar(entity{entityName});");

    sb.AppendLine($"            return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("            {");
    sb.AppendLine($"                Id{entityName} = request.Id{entityName},");
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
    sb.AppendLine("using System;");
    sb.AppendLine("using InspecaoWebAPI.DominioEntityFramework.Entidades;");
    sb.AppendLine("using System.Collections.Generic;\n");

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
    sb.AppendLine($"            var res = {entityName.ToLower()}Repositorio.Inserir(entity{entityName});");
    sb.AppendLine($"            return Task.FromResult(new {resultadoName}()");
    sb.AppendLine("            {");
    sb.AppendLine($"                {entityName} = mapper.Map<{entityName}Dto>(res),");
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
    requisicaoCode.AppendLine("using System;");
    requisicaoCode.AppendLine("using MediatR;");
    requisicaoCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Resultados.{entityName}s;");
    requisicaoCode.AppendLine("using System.Collections.Generic;\n");
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entidadeNome}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendFormat("    public class Obter{0}Requisicao : IRequest<Obter{0}Resultado>\n", entidadeNome);
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
    inputCode.AppendLine("using System;");
    inputCode.AppendLine("using System.Collections.Generic;\n");
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entidadeNome}s");
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
    resultadoCode.AppendLine("using System;");
    resultadoCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Dtos.{entityName}s;");
    resultadoCode.AppendLine("using System.Collections.Generic;\n");
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
    outputCode.AppendLine("using System;");
    outputCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Dtos.{entityName}s;");
    outputCode.AppendLine("using System.Collections.Generic;\n");
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
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

    var typeName = GetFriendlyTypeName(primaryKey.PropertyType);

    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine("using System;");
    requisicaoCode.AppendLine("using MediatR;");
    requisicaoCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Resultados.{entityName}s;");
    requisicaoCode.AppendLine("using System.Collections.Generic;\n");
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entityName}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Deletar{entityName}Requisicao : IRequest<Deletar{entityName}Resultado>");
    requisicaoCode.AppendLine("    {");
    requisicaoCode.AppendLine($"        public {typeName} {primaryKey.Name} {{ get; set; }}");
    requisicaoCode.AppendLine($"        public int IdUsuario {{ get; set; }}");
    requisicaoCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");
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
    var typeName = GetFriendlyTypeName(primaryKey.PropertyType);

    StringBuilder inputCode = new StringBuilder();
    inputCode.AppendLine("using System;");
    inputCode.AppendLine("using System.Collections.Generic;\n");
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
    inputCode.AppendLine("{");
    inputCode.AppendLine($"    public class Deletar{entityName}Input");
    inputCode.AppendLine("    {");
    inputCode.AppendLine($"        public {typeName} {primaryKey.Name} {{ get; set; }}");
    inputCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");
    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return inputCode.ToString();
}
string GenerateOutputToDeletar(string entityName)
{
    // Construir código para Output
    StringBuilder outputCode = new StringBuilder();
    outputCode.AppendLine("using System;");
    outputCode.AppendLine("using System.Collections.Generic;\n");
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
    outputCode.AppendLine("{");
    outputCode.AppendLine($"    public class Deletar{entityName}Output");
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
}

string GenerateResultadoToDeletar(string entityName)
{
    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine("using System;");
    resultadoCode.AppendLine("using System.Collections.Generic;\n");
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados.{entityName}s");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Deletar{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return resultadoCode.ToString();
}

string GenerateRequisicaoToEditar(Type entityType, string entityName)
{
    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine("using System;");
    requisicaoCode.AppendLine("using MediatR;");
    requisicaoCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Resultados.{entityName}s;");
    requisicaoCode.AppendLine("using System.Collections.Generic;\n");
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entityName}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Editar{entityName}Requisicao : IRequest<Editar{entityName}Resultado>");
    requisicaoCode.AppendLine("    {");

    foreach (PropertyInfo property in entityType.GetProperties())
    {
        // Excluir apenas a DataExclusao
        if (property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase)
            || property.PropertyType.Name.Contains("ICollection")
            || property.PropertyType.Namespace.Contains("InspecaoWebAPI")
            )
        {
            continue;
        }

        string propertyType = property.PropertyType.Name;
        string propertyName = property.Name;
        var typeName = GetFriendlyTypeName(property.PropertyType);

        if (propertyName == "IdEmpreendimento" || propertyName == "IdUsuario")
            continue;

        // Adicionar propriedade ao código de Requisicao
        requisicaoCode.AppendLine($"        public {typeName} {propertyName} {{ get; set; }}");
    }

    requisicaoCode.AppendLine($"        public int IdUsuario {{ get; set; }}");
    requisicaoCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");

    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    return requisicaoCode.ToString();
}

string GenerateInputToEditar(Type entityType, string entityName)
{
    // Construir código para Input
    StringBuilder inputCode = new StringBuilder();
    inputCode.AppendLine("using System;");
    inputCode.AppendLine("using System.Collections.Generic;\n");
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
    inputCode.AppendLine("{");
    inputCode.AppendLine($"    public class Editar{entityName}Input");
    inputCode.AppendLine("    {");

    foreach (PropertyInfo property in entityType.GetProperties())
    {
        // Excluir apenas a DataExclusao
        if (property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase)
           || property.PropertyType.Name.Contains("ICollection")
            || property.PropertyType.Namespace.Contains("InspecaoWebAPI")
           )
        {
            continue;
        }

        string propertyType = property.PropertyType.Name;
        string propertyName = property.Name;
        var typeName = GetFriendlyTypeName(property.PropertyType);
        if (propertyName == "IdEmpreendimento")
            continue;
        // Adicionar propriedade ao código de Requisicao
        inputCode.AppendLine($"        public {typeName} {propertyName} {{ get; set; }}");
    }

    inputCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");
    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return inputCode.ToString();
}

string GenerateResultadoToEditar(string entityName)
{
    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine("using System;");
    resultadoCode.AppendLine("using System.Collections.Generic;\n");
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados.{entityName}s");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Editar{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return resultadoCode.ToString();
}

string GenerateOutputToEditar(string entityName)
{
    // Construir código para Output
    StringBuilder outputCode = new StringBuilder();
    outputCode.AppendLine("using System;");
    outputCode.AppendLine("using System.Collections.Generic;\n");
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
    outputCode.AppendLine("{");
    outputCode.AppendLine($"    public class Editar{entityName}Output");
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public int Id{entityName} {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
}

string GenerateRequisicaoToInserir(Type entityType, string entityName)
{
    // Construir código para Requisicao
    StringBuilder requisicaoCode = new StringBuilder();
    requisicaoCode.AppendLine("using System;");
    requisicaoCode.AppendLine("using MediatR;");
    requisicaoCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Resultados.{entityName}s;");
    requisicaoCode.AppendLine("using System.Collections.Generic;\n");
    requisicaoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Requisicoes.{entityName}s");
    requisicaoCode.AppendLine("{");
    requisicaoCode.AppendLine($"    public class Inserir{entityName}Requisicao : IRequest<Inserir{entityName}Resultado>");
    requisicaoCode.AppendLine("    {");

    foreach (PropertyInfo property in entityType.GetProperties())
    {
        // Excluir a chave primária e a DataExclusao e Coleções
        if (property.Name.Equals($"Id{entityName}", StringComparison.OrdinalIgnoreCase)
            || property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase)
            || property.PropertyType.Name.Contains("ICollection")
            || property.PropertyType.Namespace.Contains("InspecaoWebAPI")
            )
        {
            continue;
        }

        string propertyType = property.PropertyType.Name;
        string propertyName = property.Name;
        var typeName = GetFriendlyTypeName(property.PropertyType);

        if (propertyName == "IdEmpreendimento" || propertyName == "IdUsuario")
            continue;
        // Adicionar propriedade ao código de Requisicao
        requisicaoCode.AppendLine($"        public {typeName} {propertyName} {{ get; set; }}");
    }

    requisicaoCode.AppendLine($"        public int IdUsuario {{ get; set; }}");
    requisicaoCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");
    requisicaoCode.AppendLine("    }");
    requisicaoCode.AppendLine("}");

    return requisicaoCode.ToString();
}

string GenerateInputToInserir(Type entityType, string entityName)
{
    // Construir código para Input
    StringBuilder inputCode = new StringBuilder();
    inputCode.AppendLine("using System;");
    inputCode.AppendLine("using System.Collections.Generic;\n");
    inputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
    inputCode.AppendLine("{");
    inputCode.AppendLine($"    public class Inserir{entityName}Input");
    inputCode.AppendLine("    {");

    foreach (PropertyInfo property in entityType.GetProperties())
    {
        // Excluir a chave primária e a DataExclusao
        if (property.Name.Equals($"Id{entityName}", StringComparison.OrdinalIgnoreCase)
            || property.Name.Equals("DataExclusao", StringComparison.OrdinalIgnoreCase)
            || property.PropertyType.Name.Contains("ICollection")
            || property.PropertyType.Namespace.Contains("InspecaoWebAPI")
            )
        {
            continue;
        }

        string propertyType = property.PropertyType.Name;
        string propertyName = property.Name;
        if (propertyName == "IdEmpreendimento")
            continue;
        var typeName = GetFriendlyTypeName(property.PropertyType);
        // Adicionar propriedade ao código de Requisicao
        inputCode.AppendLine($"        public {typeName} {propertyName} {{ get; set; }}");
    }

    inputCode.AppendLine($"        public int IdEmpreendimento {{ get; set; }}");
    inputCode.AppendLine("    }");
    inputCode.AppendLine("}");

    return inputCode.ToString();
}

string GenerateResultadoToInserir(string entityName)
{
    // Construir código para Resultado
    StringBuilder resultadoCode = new StringBuilder();
    resultadoCode.AppendLine("using System;");
    resultadoCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Dtos.{entityName}s;");
    resultadoCode.AppendLine("using System.Collections.Generic;\n");
    resultadoCode.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Resultados.{entityName}s");
    resultadoCode.AppendLine("{");
    resultadoCode.AppendLine($"    public class Inserir{entityName}Resultado");
    resultadoCode.AppendLine("    {");
    resultadoCode.AppendLine($"        public {entityName}Dto {entityName} {{ get; set; }}");
    resultadoCode.AppendLine("    }");
    resultadoCode.AppendLine("}");

    return resultadoCode.ToString();
}
string GenerateOutputToInserir(string entityName)
{
    // Construir código para Output
    StringBuilder outputCode = new StringBuilder();
    outputCode.AppendLine("using System;");
    outputCode.AppendLine($"using InspecaoWebAPI.Aplicacao.Dtos.{entityName}s;");
    outputCode.AppendLine("using System.Collections.Generic;\n");
    outputCode.AppendLine($"namespace InspecaoWebAPI.Models.{entityName}s");
    outputCode.AppendLine("{");
    outputCode.AppendLine($"    public class Inserir{entityName}Output");
    outputCode.AppendLine("    {");
    outputCode.AppendLine($"        public {entityName}Dto {entityName} {{ get; set; }}");
    outputCode.AppendLine("    }");
    outputCode.AppendLine("}");

    return outputCode.ToString();
}

string GenerateDTO(Type entityType)
{
    StringBuilder sb = new StringBuilder();

    var simpleEntityName = entityType.Name;

    sb.AppendLine($"using System;");
    sb.AppendLine($"using System.Collections.Generic;\n");
    sb.AppendLine($"namespace InspecaoWebAPI.Aplicacao.Dtos.{entityName}s");
    sb.AppendLine("{");
    sb.AppendLine($"    public class {simpleEntityName}Dto");
    sb.AppendLine("    {");

    foreach (var prop in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
        if (!prop.PropertyType.Name.Contains("ICollection") && !prop.PropertyType.Namespace.Contains("InspecaoWebAPI"))
        {
            var typeName = GetFriendlyTypeName(prop.PropertyType);
            sb.AppendLine($"        public {typeName} {prop.Name} {{ get; set; }}");
        }
    }

    sb.AppendLine("    }");
    sb.AppendLine("}");

    return sb.ToString();
}

string GetFriendlyTypeName(Type type)
{
    bool isNullable = false;
    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
    {
        type = Nullable.GetUnderlyingType(type);
        isNullable = true;
    }

    var typeMap = new Dictionary<string, string>
    {
        { "Int16", "short" },
        { "Int32", "int" },
        { "Int64", "long" },
        { "UInt16", "ushort" },
        { "UInt32", "uint" },
        { "UInt64", "ulong" },
        { "Single", "float" },
        { "Double", "double" },
        { "Decimal", "decimal" },
        { "Boolean", "bool" },
        { "Char", "char" },
        { "Byte", "byte" },
        { "SByte", "sbyte" },
        { "String", "string" },
        { "Object", "object" },
    };

    string name = typeMap.TryGetValue(type.Name, out var friendlyName) ? friendlyName : type.Name;
    return isNullable ? $"{name}?" : name;
}