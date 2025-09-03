using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace WpfApp1.Utils;


public class LanguageUtil
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern long ActivateKeyboardLayout(IntPtr hkl, uint Flags);

    private const uint KLF_ACTIVATE = 1;

    /// <summary>
    /// 切换输入语言 (例如俄语 = "0419")
    /// </summary>
    public static void SwitchInputLanguage(string languageHexId)
    {
        try
        {
            IntPtr hkl = LoadKeyboardLayout(languageHexId, KLF_ACTIVATE);
            ActivateKeyboardLayout(hkl, KLF_ACTIVATE);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"切换输入法失败: {ex.Message}");
        }
    }
}


public class ToolUtil
{

    // --- PInvoke ---
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private const int SW_RESTORE = 9;

    private const string Osk = "osk.exe";
    private const string TabTip = @"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe";

    /// <summary>
    /// 启用软键盘 (自动识别系统版本)
    /// </summary>
    public static void OpenKeyboard()
    {
        try
        {
            if (IsWindows10OrLater())
            {
                // Windows 10+
                OpenProcess("TabTip", TabTip);
            }
            else
            {
                // Windows 7/8
                OpenProcess("osk", Osk);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"打开键盘失败: {ex.Message}");
        }
    }

    /// <summary>
    /// 关闭软键盘
    /// </summary>
    public static void CloseKeyboard()
    {
        try
        {
            if (IsWindows10OrLater())
            {
                CloseProcess("TabTip");
            }
            else
            {
                CloseProcess("osk");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"关闭键盘失败: {ex.Message}");
        }
    }

    // --- 内部帮助方法 ---
    private static void OpenProcess(string processName, string exePath)
    {
        var existing = Process.GetProcessesByName(processName).FirstOrDefault();
        if (existing != null)
        {
            ShowWindow(existing.MainWindowHandle, SW_RESTORE);
            SetForegroundWindow(existing.MainWindowHandle);
            return;
        }

        if (File.Exists(exePath))
            Process.Start(exePath);
        else
            Process.Start(processName); // 兜底
    }

    private static void CloseProcess(string processName)
    {
        foreach (var p in Process.GetProcessesByName(processName))
        {
            if (!p.CloseMainWindow())
                p.Kill();
        }
    }

    private static bool IsWindows10OrLater()
    {
        var os = Environment.OSVersion.Version;
        // Windows 10 = 10.0.xxxx
        return os.Major >= 10;
    }
}
