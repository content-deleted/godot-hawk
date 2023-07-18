// #nullable enable

// using System.Collections.Generic;
// using System.IO;
// using BizHawk.Common.PathExtensions;
// using BizHawk.Emulation.Common;
// using BizHawk.Client.Common;

// // copy-pasted from BizHawk apart from DllPath()
// // the only purpose of this class is to work around the problem that PathUtils.DllDirectoryPath
// // is inconsistent between running in the editor and running in build (because of the way BizHawk figures it out) 
// // sort of annoying to have to have this whole file just for this
// // but it means we can avoid messing with bizhawk source
// namespace UnityHawk
// {
// public class CoreFileProvider : ICoreFileProvider
// {
//     private readonly FirmwareManager _firmwareManager;
//     private readonly IDialogParent _dialogParent;
//     private readonly PathEntryCollection _pathEntries;
//     private readonly IDictionary<string, string> _firmwareUserSpecifications;

//     public CoreFileProvider(
//         IDialogParent dialogParent,
//         FirmwareManager firmwareManager,
//         PathEntryCollection pathEntries,
//         IDictionary<string, string> firmwareUserSpecifications)
//     {
//         _dialogParent = dialogParent;
//         _firmwareManager = firmwareManager;
//         _pathEntries = pathEntries;
//         _firmwareUserSpecifications = firmwareUserSpecifications;
//     }

//     public string DllPath() => UnityHawk.dllDir;
//     //public string DllPath() => PathUtils.DllDirectoryPath;

//     // Poop
//     public string GetRetroSaveRAMDirectory(IGameInfo game)
//         => _pathEntries.RetroSaveRamAbsolutePath(game);

//     // Poop
//     public string GetRetroSystemPath(IGameInfo game)
//         => _pathEntries.RetroSystemAbsolutePath(game);

//     private (byte[] FW, string Path)? GetFirmwareWithPath(FirmwareID id)
//     {
//         var path = _firmwareManager.Request(_pathEntries, _firmwareUserSpecifications, id);
//         try
//         {
//             if (path is not null && File.Exists(path)) return (File.ReadAllBytes(path), path);
//             // else fall through
//         }
//         catch (IOException)
//         {
//             // fall through
//         }
//         return null;
//     }

//     private (byte[] FW, string Path) GetFirmwareWithPathOrThrow(FirmwareID id, string? msg)
//         => GetFirmwareWithPath(id) ?? throw new MissingFirmwareException($"Couldn't find required firmware {id}.  This is fatal{(msg is null ? "." : $": {msg}")}");

//     public byte[]? GetFirmware(FirmwareID id, string? msg = null)
//     {
//         var tuple = GetFirmwareWithPath(id);
//         if (tuple is null && msg is not null)
//         {
//             _dialogParent.ModalMessageBox($"Couldn't find firmware {id}.  Will attempt to continue: {msg}", "Warning", EMsgBoxIcon.Warning);
//         }
//         return tuple?.FW;
//     }

//     public byte[] GetFirmwareOrThrow(FirmwareID id, string? msg = null)
//         => GetFirmwareWithPathOrThrow(id, msg).FW;

//     public (byte[] FW, GameInfo Game) GetFirmwareWithGameInfoOrThrow(FirmwareID id, string? msg = null)
//     {
//         var (fw, path) = GetFirmwareWithPathOrThrow(id, msg);
//         return (fw, Database.GetGameInfo(fw, path));
//     }
// }
// }
