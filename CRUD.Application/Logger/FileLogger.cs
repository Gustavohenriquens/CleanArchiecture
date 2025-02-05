namespace CRUD.Infrastructure.Logger
{
    public static class FileLogger
    {
        private static readonly string logDirectory;

        static FileLogger()
        {
            try
            {
                // O código cria um caminho para um diretório(pasta) de logs dentro de um subdiretório específico (CRUD.Infrastructure/Logs)
                logDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "CRUD.Infrastructure", "Logs");

                // Criar o diretório caso não exista
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                    Console.WriteLine("Diretório de logs criado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Diretório de logs já existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar diretório de logs: {ex.Message}");
            }
        }

        public static void LogToFile(string title, string logMessage)
        {
            try
            {
                string fileName = Path.Combine(logDirectory, "log.txt");
                Console.WriteLine($"Arquivo de log: {fileName}");

                // Escreve no arquivo de log
                using (StreamWriter swLog = new StreamWriter(fileName, true))
                {
                    swLog.WriteLine("Log:");
                    swLog.WriteLine($"Horário : {DateTime.Now:HH:mm:ss} - Data : {DateTime.Now:yyyy-MM-dd}");
                    swLog.WriteLine($"Título: {title}");
                    swLog.WriteLine($"Mensagem: {logMessage}");
                    swLog.WriteLine("--------------------------------------\n");
                }

                Console.WriteLine("Log escrito com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo de log: {ex.Message}");
            }
        }

        public static void ProductEntry(string message, Exception ex = null)
        {
            LogToFile("Produto cadastrado no estoque", $"{message} | Exception: {ex?.Message}");
        }

        public static void ProductUpdate(string message, Exception ex = null)
        {
            LogToFile("Produto modificado no estoque", $"{message} | Erro específico: {ex?.Message}");
        }

        public static void ProductExit(string message, Exception ex = null)
        {
            LogToFile("Produto removido do estoque", $"{message} | Exception: {ex?.Message}");
        }
    }
}
