using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Contacts;
using System.Linq.Dynamic.Core;
using PhoneBook.Domain.Core.Extentions;
using PhoneBook.Domain.Shared.Contacts;
using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Contacts.Views;
using PhoneBook.Domain.Teams;
using PhoneBook.Domain.TeamMembers;
using PhoneBook.Domain.Contacts.Filters;

namespace PhoneBook.EntityFrameworkCore.Contacts
{
    public class ContactRepository : BaseRepository<PhoneBookDbContext, Contact, int>, IContactRepository
    {
        public ContactRepository(PhoneBookDbContext db) :
           base(db)
        {

        }
        public async Task<List<ContactWithDetailsView>> GetAllWithDetailsAsync(string filterText, string sorting, int skipCount = 0, int maxResultCount = 5)
        {
            var query = (await QueryableAsync())
                .Include(x => x.DirectBoss)
                .Select(x => new ContactWithDetailsView
                {
                    Id = x.Id,
                    Name = x.Name,
                    Lname = x.LName,
                    PhoneNumber = x.PhoneNumber,
                    Gender = x.Gender,
                    Team = (from team in Db.Set<Team>()
                            where team.Id == x.DirectBoss.TeamId
                            select new TeamView
                            {
                                Id = team.Id,
                                Name = team.Name
                            }).First(),
                    DirectBoss = (from member in Db.Set<TeamMember>()
                                  where member.Id == x.DirectBoss.Id
                                  select new DirectBossView
                                  {
                                      Id = member.Id,
                                      FullName = member.FullName
                                  }
                                ).First()
                }
                );

            query = ApplyFilter(query, filterText)
               .OrderBy(!string.IsNullOrEmpty(sorting) ? sorting : ContactConsts.DefaultSorting)
               .PageBy(skipCount, maxResultCount);

            return await query.ToListAsync();
        }


        public async Task<List<ContactWithDetailsView>> GetAllWithDetailsAsync(ContactWithDetailsFilter filter, string sorting, int skipCount = 0, int maxResultCount = 10)
        {
            var query = await GetQueryableForDetailsView();
            query = ApplyFilter(query, filter)
              .OrderBy(!string.IsNullOrEmpty(sorting) ? sorting : ContactConsts.DefaultSorting)
              .PageBy(skipCount, maxResultCount);

            return await query.ToListAsync();

        }


        public async Task<List<Contact>> GetAllAsync(string filterText = "", string sorting = "", int skipCount = 0, int maxResultCount = 10)
        {
            var query = await QueryableAsync();
            query = ApplyFilter(query, filterText)
                .OrderBy(!string.IsNullOrEmpty(sorting) ? sorting : ContactConsts.DefaultSorting)
                .PageBy(skipCount, maxResultCount);

            return await query.ToListAsync();
        }

        protected IQueryable<Contact> ApplyFilter(IQueryable<Contact> query, string filtertext)
        {
            return query.WhereIf(!string.IsNullOrEmpty(filtertext), x => x.Name.ToLower().Contains(filtertext.ToLower()));

        }
        protected IQueryable<ContactWithDetailsView> ApplyFilter(IQueryable<ContactWithDetailsView> query, string filtertext)
        {
            return query.WhereIf(!string.IsNullOrEmpty(filtertext), x => x.Name.ToLower().Contains(filtertext.ToLower()));

        }
        protected IQueryable<ContactWithDetailsView> ApplyFilter(IQueryable<ContactWithDetailsView> query, ContactWithDetailsFilter filter)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filter.AnyFilter), x =>
                x.Name.Contains(filter.AnyFilter) ||
                x.Lname.Contains(filter.AnyFilter) ||
                x.PhoneNumber.Contains(filter.AnyFilter) ||
                x.Team.Name.Contains(filter.AnyFilter) ||
                x.DirectBoss.FullName.Contains(filter.AnyFilter)
                )
                .WhereIf(!string.IsNullOrWhiteSpace(filter.Name), x => x.Name.Contains(filter.Name))
                .WhereIf(!string.IsNullOrWhiteSpace(filter.LName), x => x.Lname.Contains(filter.LName))
                .WhereIf(!string.IsNullOrWhiteSpace(filter.PhoneNumber), x => x.PhoneNumber.Contains(filter.PhoneNumber))
                .WhereIf(filter.Gender.HasValue, x => x.Gender == filter.Gender)
                .WhereIf(!string.IsNullOrWhiteSpace(filter.TeamName), x => x.Team.Name.Contains(filter.TeamName))
                .WhereIf(!string.IsNullOrWhiteSpace(filter.DirectBossFullName), x => x.DirectBoss.FullName.Contains(filter.DirectBossFullName));
                
            ;





        }

        protected async Task<IQueryable<ContactWithDetailsView>> GetQueryableForDetailsView()
        {
            return (await QueryableAsync())
                .Include(x => x.DirectBoss)
                .Select(x => new ContactWithDetailsView
                {
                    Id = x.Id,
                    Name = x.Name,
                    Lname = x.LName,
                    PhoneNumber = x.PhoneNumber,
                    Gender = x.Gender,
                    Team = (from team in Db.Set<Team>()
                            where team.Id == x.DirectBoss.TeamId
                            select new TeamView
                            {
                                Id = team.Id,
                                Name = team.Name
                            }).First(),
                    DirectBoss = (from member in Db.Set<TeamMember>()
                                  where member.Id == x.DirectBoss.Id
                                  select new DirectBossView
                                  {
                                      Id = member.Id,
                                      FullName = member.FullName
                                  }
                                ).First()
                }
                );
        }
        public async Task<long> GetCountAsync(string filterText)
        {
            var query = await QueryableAsync();
            query = ApplyFilter(query, filterText);

            return await query.CountAsync();
        }

        public async Task<Contact> GetByNameAsync(string name, string lname)
        {
            var contact = await Db.Contacts.FirstOrDefaultAsync(x => x.Name == name && x.LName == lname);
            if (contact == null)
            {
                throw new ContactNotFoundException(name, lname);
            }
            return contact;
        }

        public async Task<long> GetCountAsync(ContactWithDetailsFilter filter)
        {
            var query = await GetQueryableForDetailsView();
            query = ApplyFilter(query, filter);

            return await query.CountAsync();
        }
    }
}
