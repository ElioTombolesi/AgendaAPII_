﻿using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPII.Data.Repository.Implementations
{
    public class ContactRepository :IContactRepository

    {
        private readonly AgendaContext _context;

        public ContactRepository(AgendaContext context)
        {
            _context = context;
        }

        public async Task DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task EditContact(Contact contact)
        {
            var contactEdit = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);

            if (contactEdit != null)
            {

            
            contactEdit.Name = contact.Name;
            contactEdit.Dispositivos = contact.Dispositivos;
           


            await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Contact>> GetAllContacts(int id)

        {

            return await _context.Contacts.Include(x => x.Dispositivos).Where(x => x.User.Id == id).ToListAsync();


        }



        public async Task<Contact?> GetOneById(int id)
        {

            return await _context.Contacts.Include(x => x.Dispositivos).FirstOrDefaultAsync(x => x.Id == id);



        }

        public async Task<Contact> NewContact(Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        
    }
}
