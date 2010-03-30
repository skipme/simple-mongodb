﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30128.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pls.SimpleMongoDb.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pls.SimpleMongoDb.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified connectionstring name &quot;{0}&quot; could not be found..
        /// </summary>
        public static string ConnectionInfo_MissingConnectionStringEntry {
            get {
                return ResourceManager.GetString("ConnectionInfo_MissingConnectionStringEntry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The command did not execute as expected! MongoDb returned status &quot;not ok&quot;..
        /// </summary>
        public static string DatabaseCommand_CommandWasNotOk {
            get {
                return ResourceManager.GetString("DatabaseCommand_CommandWasNotOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OnReadResponse-method has not been implemented in command that recieves an response..
        /// </summary>
        public static string MongoCommand_OnReadResponseNotImplemented {
            get {
                return ResourceManager.GetString("MongoCommand_OnReadResponseNotImplemented", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connection allready established.
        /// </summary>
        public static string MongoConnection_AllreadyEstablished {
            get {
                return ResourceManager.GetString("MongoConnection_AllreadyEstablished", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pipestream can not be aquired while not connected to server..
        /// </summary>
        public static string MongoConnection_NoPipestreamWhileDisconnected {
            get {
                return ResourceManager.GetString("MongoConnection_NoPipestreamWhileDisconnected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No specific message from MongoDB..
        /// </summary>
        public static string MongoErrorMessage_Default {
            get {
                return ResourceManager.GetString("MongoErrorMessage_Default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MongoId-string should be 24chars without dashes..
        /// </summary>
        public static string MongoId_FromStringInvalidLen {
            get {
                return ResourceManager.GetString("MongoId_FromStringInvalidLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OpCode could not be read from the response..
        /// </summary>
        public static string ResponseReader_MissingOpCodeInResponse {
            get {
                return ResourceManager.GetString("ResponseReader_MissingOpCodeInResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The OpCode &quot;{0}&quot; was expected, but &quot;{1}&quot; was retrieved..
        /// </summary>
        public static string ResponseReader_WrongOpCodeInResponse {
            get {
                return ResourceManager.GetString("ResponseReader_WrongOpCodeInResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The command needs a value for &quot;NodeName&quot;..
        /// </summary>
        public static string SimoCommand_IsMissingNodeName {
            get {
                return ResourceManager.GetString("SimoCommand_IsMissingNodeName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type is not supported. Can not convert from: &quot;{0}&quot;..
        /// </summary>
        public static string SimoIdJsonConverter_InvalidType {
            get {
                return ResourceManager.GetString("SimoIdJsonConverter_InvalidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The bytes representing the ObjectId must be 12-bytes long and can not be all empty..
        /// </summary>
        public static string SimoObjectId_InvalidBytes {
            get {
                return ResourceManager.GetString("SimoObjectId_InvalidBytes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The byte-array representing the counterpart of the ObjectId has an invalid length. The length should be {0} bytes..
        /// </summary>
        public static string SimoObjectIdCounterPart_InvalidBytesLen {
            get {
                return ResourceManager.GetString("SimoObjectIdCounterPart_InvalidBytesLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An ObjectId that has empty bytes can not be serialized. The ObjectId must have an unique content..
        /// </summary>
        public static string SimoObjectIdJsonConverter_InvalidId {
            get {
                return ResourceManager.GetString("SimoObjectIdJsonConverter_InvalidId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The byte-array representing the machinepart of the ObjectId has an invalid length. The length should be {0} bytes..
        /// </summary>
        public static string SimoObjectIdMachinePart_InvalidBytesLen {
            get {
                return ResourceManager.GetString("SimoObjectIdMachinePart_InvalidBytesLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The byte-array representing the processpart of the ObjectId has an invalid length. The length should be {0} bytes..
        /// </summary>
        public static string SimoObjectIdProcessPart_InvalidBytesLen {
            get {
                return ResourceManager.GetString("SimoObjectIdProcessPart_InvalidBytesLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The byte-array representing the timepart of the ObjectId has an invalid length. The length should be 4 bytes..
        /// </summary>
        public static string SimoObjectIdTimePart_InvalidBytesLen {
            get {
                return ResourceManager.GetString("SimoObjectIdTimePart_InvalidBytesLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The use of regular expression are only supported in BsonWriter..
        /// </summary>
        public static string SimoRegexJsonConverter_OnlySupportsBsonWriter {
            get {
                return ResourceManager.GetString("SimoRegexJsonConverter_OnlySupportsBsonWriter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The command needs a value for &quot;DatabaseName&quot;..
        /// </summary>
        public static string SimpleCommand_MissingDatabaseName {
            get {
                return ResourceManager.GetString("SimpleCommand_MissingDatabaseName", resourceCulture);
            }
        }
    }
}
