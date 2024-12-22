using RestWithASPNET.Model;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        //métodos da Interface 
      
        Person Create(Person person);

        Person FindById(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);
        
    }
}
