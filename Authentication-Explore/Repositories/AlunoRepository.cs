using Authentication_Explore.Entities;
using Authentication_Explore.Interfaces;

namespace Authentication_Explore.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private Guid Guid { get; set; }
    private readonly ILogger<AlunoRepository> logger;
    private readonly IList<Aluno> alunos = [];
    private IAlunoRepository _alunoRepositoryImplementation;

    public AlunoRepository(ILogger<AlunoRepository> logger)
    {
        this.logger = logger;
        this.Guid = Guid.NewGuid();
    }

    public int Inserir(Aluno aluno)
    {
        logger.LogDebug("Inicializando método Inserir. Guid: {Guid}", Guid.ToString());
        int id = alunos.Select(x => x.Id).Any() ? alunos.Select(x => x.Id).Max() + 1 : 1;
        aluno.Id = id;
        alunos.Add(aluno);
        return id;
    }

    public List<Aluno> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Aluno Retornar(int id)
    {
        throw new NotImplementedException();
    }

    public Aluno Retonar(int id)
    {
        logger.LogWarning("Inicializando método Retornar. Guid: {Guid}", Guid.ToString());
        return alunos.FirstOrDefault(x => x.Id == id, new Aluno{Nome = ""});
    }
}