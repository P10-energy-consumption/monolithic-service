using Dapper;
using monolithic_service.Database.Interfaces;
using monolithic_service.Models;
using monolithic_service.Repositories.Interfaces;
using ServiceStack;
using System.Linq;

namespace monolithic_service.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public StoreRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<InventoryLine>> GetInventory()
        {
            var result = new List<InventoryLine>();
            var sql = @" /* PetStore.Store.Api */
select p.Status, count(p.Id) from pets.pet p
where p.IsDelete = false
group by p.Status";

            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    result = (await _connection.QueryAsync<InventoryLine>(sql)).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }

                return result;
            }
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            var result = -1;
            var sql = @" /* PetStore.Store.Api */
delete from orders.order where id = @Id";

            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    result = await _connection.ExecuteAsync(sql, new { id = orderId });
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }
            return result; 
        }

        public async Task<Order> PostOrder(Order order)
        {
            var sql = @" /* PetStore.Store.Api */
insert into orders.order (id, petid, quantity, shipdate, status, complete, created, createdby) 
values (@id, @petid, @quantity, @shipdate, @status, @complete, current_timestamp, 'PetStore.Store.Api');";

            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    await _connection.ExecuteAsync(sql, order);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }

            return order;
        }

        public async Task<Order> GetOrders(int orderId)
        {
            var sql = @" /* PetStore.Store.Api */
select o.Id, o.Status, o.PetId, o.Quantity, o.ShipDate, o.Complete 
from orders.order o
where o.IsDelete = false
and o.id = @id";

            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    var result = await _connection.QuerySingleAsync<Order>(sql, new { id = orderId });
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}
