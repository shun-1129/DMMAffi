using MasterDataCreator.Infrastructures.Implement;
using MasterDataCreator.Infrastructures.Interface;

namespace MasterDataCreator
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            IDBAccessor dbAccessor = DBAccessor.CreateInstance ();

            Task.Run ( async () =>
            {
                Worker worker = new Worker ( dbAccessor );
                await worker.ExecuteAsync ();
            } ).Wait ();
        }
    }
}
