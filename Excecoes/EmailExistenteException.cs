namespace MangaI.Excecoes;

public class EmailExistenteException : Exception
{
     public EmailExistenteException() : base("Já existe um usuário com esse email")
     {
        
     }
}

