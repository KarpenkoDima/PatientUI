//using SOPB.BAL.Utilities;
//using SOPB.DAL.ConnectionManager;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SOPB.BAL.AccessData
//{
//    internal class CustomerAccess
//    {
//        private  string whereClasure = String.Empty;
//        private  IConvertible value;
//        private  string dbType = String.Empty;
//        private string _connectionString;

//        public Dictionary<string, string> ParametersForUsp = new Dictionary<string, string>()
//        { {Utilites.QueryCriteria.Bithday, "@BirthOfDay:;@BirthOfDayEnd:;@predicate:10"},
//            {Utilites.QueryCriteria.Address, "@City:100;@NameStreet:100"},
//            {Utilites.QueryCriteria.LastName, "@LastName:100"}
//        };
        

//        public CustomerAccess(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public DbType DbTypeConversionKey(string fullName)
//        {

//            Dictionary<string, DbType> conversionKey = new Dictionary<string, DbType>
//            { {"System.Int64", DbType.Int64},
//                {"System.Byte[]",DbType.Binary},
//                {"System.Boolean",DbType.Boolean},
//                {"System.String",DbType.String},
//                {"System.DateTime",DbType.DateTime},
//                {"System.Decimal",DbType.Decimal},
//                {"System.Double",DbType.Double},
//                {"System.Int32", DbType.Int32},
//                {"System.Int16", DbType.Int16},
//                {"System.Byte", DbType.Byte},
//                {"System.Guid", DbType.Guid},
//                {"System.Object", DbType.Object},
//                {"System.Single", DbType.Single},
//                {"System.Char", DbType.AnsiStringFixedLength}};
//            if (conversionKey.ContainsKey(fullName))
//            {
//                return conversionKey[fullName];
//            }
//            return DbType.Object;
//        }

//        internal object GetData()
//        {
//            throw new NotImplementedException();
//        }

//        internal void GetDataByCriteria<T>(string criteria, T[] values) where T : IComparable<T>
//        {
//            throw new NotImplementedException();
//        }

//        protected static SqlDbType SqlTypeConversionKey(string fullName)
//        {

//            var conversionKey = new Dictionary<string, SqlDbType>
//            { {"System.Int64", SqlDbType.BigInt},
//                {"System.Byte[]",SqlDbType.Binary},
//                {"System.Boolean",SqlDbType.Bit},
//                {"System.String",SqlDbType.VarChar},
//                {"System.DateTime",SqlDbType.DateTime},
//                {"System.Decimal",SqlDbType.Decimal},
//                {"System.Double",SqlDbType.Float},
//                {"System.Int32", SqlDbType.Int},
//                {"System.Int16", SqlDbType.SmallInt},
//                {"System.Byte", SqlDbType.TinyInt},
//                {"System.Guid", SqlDbType.UniqueIdentifier},
//                {"System.Object", SqlDbType.Variant},
//                {"System.Single", SqlDbType.Real},
//                {"System.Char", SqlDbType.NChar}};
//            if (conversionKey.ContainsKey(fullName))
//            {
//                return conversionKey[fullName];
//            }
//            return SqlDbType.Variant;
//        }

//        public void SetConnection()
//        {
//            ConnectionManager.SetConnection(_connectionString);
//        }
//    }
//}
