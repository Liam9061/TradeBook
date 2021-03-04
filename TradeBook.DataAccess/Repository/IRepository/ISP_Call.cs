using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TradeBook.DataAccess.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        //Interger or boolean value returned.
        T Single<T>(string procedureName, DynamicParameters param = null);

        void Execute(string procedureName, DynamicParameters param = null);
        //Retrieve complete row
        T OneRecord<T>(string procedureName, DynamicParameters param = null);

        //All of the rows
        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);

        //Retrieve 2 tables
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);

    }
}