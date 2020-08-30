using Accounting.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Accounting.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
