using Authentication_Explore.Entities;
using Authentication_Explore.Interfaces;


namespace Authentication_Explore.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository alunoRepository;
    private IAlunoService _alunoServiceImplementation;

    public AlunoService(IAlunoRepository alunoRepository)
    {
        this.alunoRepository = alunoRepository;
    }

    public Aluno RetornarAluno(int id)
    {
        return alunoRepository.Retornar(id);
    }

    public int CriarAluno(Aluno dadosaAluno)
    {
        return alunoRepository.Inserir(dadosaAluno);
    }

    public List<Aluno> RetorarAlunos()
    {
        return _alunoServiceImplementation.RetorarAlunos();
    }

    public List<Aluno> RetornarAlunos()
    {
        return alunoRepository.ObterTodos();
    }
}