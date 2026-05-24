using System.Linq.Expressions;
namespace StuMap.DAL.Repositories.Interfaces
{

    /// <summary>
    /// Defines a generic repository for executing core CRUD operations against a database context.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by this repository.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Exposes the underlying database set as an IQueryable to allow custom, deferred LINQ operations.
        /// </summary>
        /// <remarks>
        /// The query is execution-deferred; it will not hit the database until a terminal method 
        /// like ToListAsync(), FirstOrDefaultAsync(), or CountAsync() is called.
        /// </remarks>
        /// <returns>An IQueryable stream of the entity collection.</returns>
        IQueryable<T> Query();

        /// <summary>
        /// Retrieves a single entity matching the specified primary key.
        /// </summary>
        /// <param name="id">The primary key value of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the entity if found; otherwise, null.</returns>
        Task<T?> GetByIdAsync(object id);

        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a collection of all entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Finds entities matching a specific conditional lambda expression.
        /// </summary>
        /// <param name="predicate">A lambda expression representing the filter criteria (e.g., x => x.IsActive).</param>
        /// <returns>A task representing the asynchronous operation, containing a filtered collection of entities.</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Tracks a new entity for insertion into the database upon committing changes.
        /// </summary>
        /// <param name="entity">The entity instance to add.</param>
        /// <returns>A task representing the asynchronous queue operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Tracks a collection of new entities for insertion into the database upon committing changes.
        /// </summary>
        /// <param name="entities">The collection of entity instances to add.</param>
        /// <returns>A task representing the asynchronous queue operation.</returns>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Attaches a disconnected entity and forces its state to Modified, ensuring all properties are updated in the database.
        /// </summary>
        /// <remarks>
        /// This method is primarily used for disconnected scenarios (e.g., entity models bound directly from API requests). 
        /// It operates completely in-memory and does not require asynchronous execution.
        /// </remarks>
        /// <param name="entity">The entity instance to mark as modified.</param>
        void Update(T entity);

        /// <summary>
        /// Tracks an existing entity for deletion from the database upon committing changes.
        /// </summary>
        /// <param name="entity">The entity instance to remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Tracks a collection of existing entities for deletion from the database upon committing changes.
        /// </summary>
        /// <param name="entities">The collection of entity instances to remove.</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Persists all pending tracking changes made within the current scope to the underlying database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing the number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
