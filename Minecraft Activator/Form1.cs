using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Minecraft_Activator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }



        // Импорт функции для завершения процесса
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        // Удаление файла в system32 Удаление файла в system32 Удаление файла в system32 Удаление файла в system32 Удаление файла в system32 
        private void btnDeleteSystem32_Click(object sender, EventArgs e)
        {
            string system32Path = System32Path.Text; // Получаем путь из TextBox
            TryDeleteFile(system32Path, "System32");
        }
        // Удаление файла в system32 Удаление файла в system32 Удаление файла в system32 Удаление файла в system32 Удаление файла в system32 

        // Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64
        private void btnDeleteSysWow64_Click(object sender, EventArgs e)
        {
            string sysWow64Path = SysWow64Path.Text; // Получаем путь из TextBox
            TryDeleteFile(sysWow64Path, "SysWOW64");
        }
        // Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64 Удаление файла syswow64

        // ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 
        private void btnReplaceSystem32_Click(object sender, EventArgs e)
        {
            try
            {
                string system32Path = System32Path.Text; // Получаем путь из TextBox

                // Открываем диалог для выбора файла для System32
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Select file to replace in System32",
                    Filter = "DLL Files|*.dll"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFileSystem32 = openFileDialog.FileName;
                    TryReplaceFile(sourceFileSystem32, system32Path, "System32");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 ЗАМЕНА ФАЙЛА В SYSTEM32 

        // ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 
        private void btnReplaceSysWow64_Click(object sender, EventArgs e)
        {
            try
            {
                string sysWow64Path = SysWow64Path.Text; // Получаем путь из TextBox

                // Открываем диалог для выбора файла для SysWOW64
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Select file to replace in SysWOW64",
                    Filter = "DLL Files|*.dll"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFileSysWow64 = openFileDialog.FileName;
                    TryReplaceFile(sourceFileSysWow64, sysWow64Path, "SysWOW64");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 ЗАМЕНА ФАЙЛА SYSWOW64 

        // ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА 
        private void TryDeleteFile(string filePath, string location)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lockingProcesses = FindLockingProcesses(filePath);
                    if (lockingProcesses.Any())
                    {
                        foreach (var process in lockingProcesses)
                        {
                            try
                            {
                                TerminateProcess(process.Handle, 0);
                                process.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error terminating process: {ex.Message}");
                            }
                        }
                    }

                    File.Delete(filePath);
                    MessageBox.Show($"File in {location} removed.");
                }
                else
                {
                    MessageBox.Show($"File in {location} not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА ПОПЫТКА УДАЛЕНИЯ ФАЙЛА 

        // ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА
        private void TryReplaceFile(string sourceFile, string destinationFile, string location)
        {
            try
            {
                var lockingProcesses = FindLockingProcesses(destinationFile);
                if (lockingProcesses.Any())
                {
                    foreach (var process in lockingProcesses)
                    {
                        try
                        {
                            TerminateProcess(process.Handle, 0);
                            process.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error terminating process: {ex.Message}");
                        }
                    }
                }

                File.Copy(sourceFile, destinationFile, true);
                MessageBox.Show($"File at {location} has been replaced.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        // ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА ПОПЫТКА ЗАМЕНЫ ФАЙЛА

        // ПОИСК ПРОЦЕССА КОТОРЫЙ БЛОКИРУЕТ ДОСТУП К УДАЛЕНИЮ ФАЙЛА ПОИСК ПРОЦЕССА КОТОРЫЙ БЛОКИРУЕТ ДОСТУП К УДАЛЕНИЮ ФАЙЛА 
        private Process[] FindLockingProcesses(string filePath)
        {
            var processes = Process.GetProcesses();
            var lockingProcesses = processes.Where(process =>
            {
                try
                {
                    return process.Modules.Cast<ProcessModule>().Any(module =>
                        module.FileName.Equals(filePath, StringComparison.OrdinalIgnoreCase));
                }
                catch
                {
                    return false;
                }
            }).ToArray();

            return lockingProcesses;
        }
        // ПОИСК ПРОЦЕССА КОТОРЫЙ БЛОКИРУЕТ ДОСТУП К УДАЛЕНИЮ ФАЙЛА ПОИСК ПРОЦЕССА КОТОРЫЙ БЛОКИРУЕТ ДОСТУП К УДАЛЕНИЮ ФАЙЛА 

        // ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА 
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        // ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА ПРОВЕРКА ЕСТЬ ЛИ ПРАВА АДМИНА 

        // При запуске программы проверяем права администратораПри запуске программы проверяем права администратора
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("The program must be run with administrator rights.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        // При запуске программы проверяем права администратораПри запуске программы проверяем права администратора

        //ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создано для активации игры \"Minecraft Windows 10 Edition\" Версия 1.0", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT ABOUT 

        //EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT 
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT EXIT 

        //DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // URI для открытия Minecraft в Microsoft Store
                string storeUri = "ms-windows-store://pdp/?ProductId=9NBLGGH2JHXJ";

                // Запуск процесса для открытия URI
                Process.Start(new ProcessStartInfo
                {
                    FileName = storeUri,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT DOWNLOAD MINECRAFT 

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Пути к исходным файлам (мои подставные)
                string hubDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string activateKeyDirectory = Path.Combine(hubDirectory, "ACTIVATE KEY");

                string system32SourcePath = Path.Combine(activateKeyDirectory, "System32", "Windows.ApplicationModel.Store.dll");
                string sysWow64SourcePath = Path.Combine(activateKeyDirectory, "SysWOW64", "Windows.ApplicationModel.Store.dll");

                // Проверяем, существуют ли исходные файлы
                if (!File.Exists(system32SourcePath))
                {
                    MessageBox.Show("Файл для System32 не найден в ACTIVATE KEY!");
                    return;
                }
                if (!File.Exists(sysWow64SourcePath))
                {
                    MessageBox.Show("Файл для SysWOW64 не найден в ACTIVATE KEY!");
                    return;
                }

                // Пути к целевым файлам (системные)
                string system32DestPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.System),
                    "Windows.ApplicationModel.Store.dll"
                );
                string sysWow64DestPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.SystemX86),
                    "Windows.ApplicationModel.Store.dll"
                );

                // Удаляю оригинальные файлы (если существуют)
                TryDeleteFile(system32DestPath, "System32");
                TryDeleteFile(sysWow64DestPath, "SysWOW64");

                // Даём системе время завершить процессы (опционально)
                System.Threading.Thread.Sleep(1000);

                // Копируем подставные файлы
                File.Copy(system32SourcePath, system32DestPath, overwrite: true);
                File.Copy(sysWow64SourcePath, sysWow64DestPath, overwrite: true);

                MessageBox.Show("Файлы заменены успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Метод для завершения процессов, использующих файл
        private void TerminateProcessesUsingFile(string filePath)
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    // Проверка, использует ли процесс файл
                    var modules = process.Modules.Cast<ProcessModule>();
                    if (modules.Any(module => module.FileName.Equals(filePath, StringComparison.OrdinalIgnoreCase)))
                    {
                        // Завершение процесса
                        TerminateProcess(process.Handle, 0);
                        process.Dispose();
                    }
                }
                catch
                {
                    // Игнорируем процессы, к которым нет доступа
                }
            }
        }
    }
}