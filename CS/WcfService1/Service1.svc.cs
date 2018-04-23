using DevExpress.Xpo;

using DevExpress.Xpo.DB;
using System.ServiceModel;

namespace WcfService1 {

    public class Service1 : DataStoreService {

        public static IDataStore DataStore;

        static Service1() {

            string connectionString = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB");

            DataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema);
            
        }
        public Service1()

            : base(DataStore) {
        }

    }

}
