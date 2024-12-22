using RestWithASPNET.Model;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        //métodos da Interface 
      
        Book Create(Book book);

        Person FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);
        
    }
}
