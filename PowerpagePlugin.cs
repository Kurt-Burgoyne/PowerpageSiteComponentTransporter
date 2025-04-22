using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace SiteComponentTransporter {
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Powerpage Site Component Transporter"),
        ExportMetadata("Description", "Transport virtual power page site components from one environment to another."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAACXBIWXMAAC4jAAAuIwF4pT92AAACoElEQVRIieWXzWsTURDAf+9tttn00LSnqkUFS217FLwIHgQPKn5Rhap/gRfBi170X/Ag4lE8KCKIHkRo8eJRVHr341ARraClJm1Mm81+jIeX1GTzknZXqgcHctjJzPtlZmfmTZSI8C9E/xMqkAN4cPtbUn8duJLQXQXuNB9UqAi2V6kc/gKRSvpPAZ+BORv00vBBA7ZIPzCY0BXanhTUJsqIEhRt4DPAI+ArcAR4awN0S3XcUxdqguFV6iMVVNR2xFngIeAAO4FnwGQacE9RQG2yZLx/1+Z0A9rXYjoKPAXG/xisQk2wbZX6yE9UuO5+DrgPuBaXMUzkbfAMEQu1ySXQ0oz2PHCP9kg3hKcCm0pepb6jigq1Ai7Smd5e8BfAfqBrVdtFFFF/CG4MvtMP7AZuACGm+I4B+xJeT4B5oI7plAlgLh1YC7lyHlVzQFNFuJawGLKA7wIzHUel4Yoj5BY98p8GEDeymdiKq2DRpS8ucQTv3RDKd0Bln/Ppq9oRnB8FE3XONme2CgyIFvIfBk0fd4zpLQSjBO078NfBWtCVPvIfi5nTnf0+bhSZXstWZJnBogVnJU/ffBFx00fdDVy36GodcCfGez+ErrqIThd1c3JdBnYBZUzDH7DYTjVsFOABC2i55VRc0VWX2LMOlA3BC8DNDWyPNz4AAXAaURJ7EZKPWu/lTUkz1Y+Bo8DKJnyWgEPArAo0/p5loqKPitP1Ves7fo65W5d72C8CJ4CXCEghwN9bMv2cUpIes8AF7JF/B04Br8BsIv7oMlExSB2tDdwKr3aDIoq4ELI2XkJ1rraZwWDuz2nAB0rASeB188tmtPFAPblTO5azrL+s1yIwg3nnS8Cbda0oYi/EHysnV1swWaokdIHtcPXf/Xf6Bf6Y0vXJ3EVAAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAYAAACOEfKtAAAACXBIWXMAAC4jAAAuIwF4pT92AAAD4ElEQVR4nO2bS4sdRRSAv4nDOBNwTBi0wIUrQUGIr0TUXJzoJJpoXKgghEK3bsp/U7/A0AQEEYk60TxMQvnAtwHBhX+gFEmMkDGijovqyPViJt19qqanr+db3X7UOcVH3e569cz6+jpKd7b1XYGhowKFqEAhKlCIChSiAoWoQCEqUIgKFKIChczmDFb52HhcaJ2ZyZn7v/Ax3OXM6IeSOaa2BfoYdgHf+xieK5lnKgX6GO4HvgVuAl73MTxbKtfUCfQxPAh8PXZqB/COj+FQiXxTJdDHsBv48jqXj/oYDubOOTUCa3mfb3DLErCaW+JUCPQxPMLG8sZ5I6fEwQv0MTwGfNKiyC3AMR/DgRz5By2wlvdRh6I7gPd8DE9K6zBYgT6Gx+km7xqzpJa44mPo3KkfpMBa3rkMoW4HTgH7ugYYnEAfwz7yyBvnTR/DSpeCgxJYP7M+LBB6J0nictuCgxHoY9gPnC6Y4lbgRP14aMwgBPoYngJObkKqeVI/sbHELS/Qx/A88H7BFJNTcAY403TsnHU+sBCvAeeBhfr4EvAXcDOpP3cZuAK0GV0cBR6uy38G/ATsIr2VvwPmgCPA6o0CDUHgYWDWmdHlayd8DEvAmjOjK/XxHHC1RcxXnRmtjcWbBxacGV0cO7fYJNBMzs1Ffc5I+xga53ZmlC33ln8GbnVUoBAVKEQFClGBQlSgEBUoRAUKUYFCVKAQFShEBQpRgUJUoBAVKEQFClGBQlSgEBUoRAUKUYFCGgmsfFycON5Z+Tg/cW6BFlQ+zo393l75uDSZs/Jxe5uYfdB0XdhXPt4B/A7cC/wIXKh8vI20QH2JtEDdhrdrQYt1+auVj9tIi90Aa8CfgHgTZEmaCjwGHCd9dwFwJ7CbtC1ihrQd4u6WuZvsJHihZcxNp9Ff2DqzSmoJceJSyc+1nrbOvFUwfhYav0SsM+eBl4DfylXnHw5YZz7YhDxiWr2Fa4kHgV/KVAeAFevMqYLxs9K6G2OdOQe8CFy80b0deMI6c6ZA3GJ06gdaZ06TJOZk2TpzNnPM4kg60meB/aQujZTl+vEwODoLtM6s1y3xCPCHoA57hyoPMgzl6mfWM6TOcFv2Wmc+ltahT7KMha0zJ0kt8dcWxR4dujzIOJlgnTlB6ic2YY915tNcufsk62xMLfEQ8PMGt+2xznyRM2+fZJ/OqiW+fJ3LD02TPCg0H1iPnQ/z7xfLA9aZr0rk65NiE6rWmXeBV0hTUvdZZ74platPis5IW2eOA/dYZy6UzNMnWb8T+T+iayJCVKAQFShEBQpRgUJUoBAVKEQFClGBQlSgkL8BTJoGcQ4TAeUAAAAASUVORK5CYII="),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class PowerpagePlugin : PluginBase {
        public override IXrmToolBoxPluginControl GetControl () {
            return new window();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public PowerpagePlugin () {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler (object sender, ResolveEventArgs args) {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null) {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath)) {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}