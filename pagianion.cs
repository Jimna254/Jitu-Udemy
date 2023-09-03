


int pageNumber = 2;
int pageSize = 10;

var query = context.Items.OrderBy(item => item.Name);
var pagedItems = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


var pagedItems = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();



var pagedItems = query.Offset((pageNumber - 1) * pageSize).Fetch(pageSize).ToList();


public class PaginatedList<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public List<T> Items { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Items = items;
    }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}


int pageNumber = 2;
int pageSize = 10;

var query = context.Items.OrderBy(item => item.Name);
var count = await query.CountAsync();
var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
var paginatedList = new PaginatedList<Item>(items, count, pageNumber, pageSize);

