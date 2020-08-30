using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;

namespace Accounting.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
