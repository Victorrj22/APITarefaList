 using Flunt.Notifications;
 using Flunt.Validations;

 namespace ApiList.ViewModels
{
    public class CreateAtividadeViewModels : Notifiable<Notification>
    {
        public string Title { get; set; }

        public Atividades MapTo()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o título da tarefa")
                .IsGreaterThan(Title, 5, "O título deve conter mais de 5 caracteres");
            AddNotifications(contract);

            return new Atividades(Guid.NewGuid(), Title, false);

        }
    }
}
