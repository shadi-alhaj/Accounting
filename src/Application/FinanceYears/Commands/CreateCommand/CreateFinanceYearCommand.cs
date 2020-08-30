using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.FinanceYears.Commands.CreateCommand
{
    public class CreateFinanceYearCommand : IRequest<Guid>
    {
        public int Year { get; set; }       
        public Guid CustomerId { get; set; }      

        public class CreateFinanceYearCommandHandler : IRequestHandler<CreateFinanceYearCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateFinanceYearCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateFinanceYearCommand request, CancellationToken cancellationToken)
            {
                var entity = new FinanceYear
                {
                    Year = request.Year,
                    CustomerId = request.CustomerId
                };

                _context.FinanceYears.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}