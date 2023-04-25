namespace WebApplication1.Models
{
    public interface IClientsRepository
    {
        //Получение списка пользователей с краткой информацией
        IEnumerable<Client> GetAll();

        //Получение пользователя по ID
        Client Get(long id);

        //Редактирование пользователя
        void Update(Client client);

        //Удаление пользователя
        Client Remove(long id);

        //Создание пользователя
        void Create(Client client);
    }
}
