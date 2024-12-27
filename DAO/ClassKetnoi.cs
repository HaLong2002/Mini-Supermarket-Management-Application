using Newtonsoft.Json;

class LocalConfig
{
   public string connection;
}
namespace SieuThiMini.DAO
{
    class ClassKetnoi
    {
        private static string _connection = "";
        public static string ConnectionString {
            get {
                /** === LƯU Ý ===
                 * Để tránh xung đột connection string khi có người mới đẩy code lên, 
                 * mỗi người tự tạo 1 file local-variable.json trong project và dán connection string của mình vào 
                 * mình đã setup gitignore để khi đẩy code lên thì file đó sẽ được ignore, nên nó chỉ lưu ở local (máy của bạn)
                 * - format của file local-variable như sau: 
                 * {
                 *  "connection": "Đặt connection string của bạn ở đây nhé"
                 * }
                 * - file local-variable được đặt cùng cấp với BUS, DAO, DTO
                 */
                // Path to your JSON file
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
                string filePath = Path.Combine(projectRootPath,"..", "local-variable.json");

                // Read JSON content from the file
                string jsonString = File.ReadAllText(filePath);
                LocalConfig jsonData = JsonConvert.DeserializeObject<LocalConfig>(jsonString);
                _connection = jsonData.connection;
                return _connection;
            } set
            {
                _connection = value;
            }
        }
    }
}
