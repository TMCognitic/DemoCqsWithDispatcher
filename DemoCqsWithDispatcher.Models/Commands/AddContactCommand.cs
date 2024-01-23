using DemoCqsWithDispatcher.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;

namespace DemoCqsWithDispatcher.Models.Commands
{
    public class AddContactCommand : ICommandDefinition
    {
        public AddContactCommand(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public string Nom { get; init; }
        public string Prenom { get; init; }
    }

    public class AddContactCommandHandler : ICommandHandler<AddContactCommand>
    {
        private readonly IList<Contact> _contacts;

        public AddContactCommandHandler(IList<Contact> contacts)
        {
            _contacts = contacts;
        }

        public ICommandResult Execute(AddContactCommand command)
        {
            int id = (_contacts.Count > 0) ? _contacts.Max(c => c.Id) + 1 : 1;

            Contact contact = new Contact(id, command.Nom, command.Prenom);
            _contacts.Add(contact);
            return ICommandResult.Success();
        }
    }
}
