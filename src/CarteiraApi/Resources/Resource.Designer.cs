﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarteiraApi.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CarteiraApi.Resources.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to Item já cadastrado.
        /// </summary>
        public static string AlreadyExists {
            get {
                return ResourceManager.GetString("AlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Razão social da empresa.
        /// </summary>
        public static string CompanyName {
            get {
                return ResourceManager.GetString("CompanyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {0} deve ser maior que zero.
        /// </summary>
        public static string GreaterThanZero {
            get {
                return ResourceManager.GetString("GreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {0} atingiu o limite de {1} caracteres.
        /// </summary>
        public static string MaxSize {
            get {
                return ResourceManager.GetString("MaxSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operação(Buy ou Sell).
        /// </summary>
        public static string Operation {
            get {
                return ResourceManager.GetString("Operation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preço.
        /// </summary>
        public static string Price {
            get {
                return ResourceManager.GetString("Price", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quantidade.
        /// </summary>
        public static string Quantity {
            get {
                return ResourceManager.GetString("Quantity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {0} é obrigatório.
        /// </summary>
        public static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ação.
        /// </summary>
        public static string StockCode {
            get {
                return ResourceManager.GetString("StockCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Código da ação.
        /// </summary>
        public static string StockCodeRequired {
            get {
                return ResourceManager.GetString("StockCodeRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id da ação.
        /// </summary>
        public static string StockId {
            get {
                return ResourceManager.GetString("StockId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A ação não foi encontrada.
        /// </summary>
        public static string StockNotFound {
            get {
                return ResourceManager.GetString("StockNotFound", resourceCulture);
            }
        }
    }
}
