using Authentication_Explore.Entities;

namespace Authentication_Explore.Interfaces;

public interface IAlunoRepository
{
    int Inserir(Aluno aluno);
    List<Aluno> ObterTodos();
    Aluno Retornar(int id);
}