using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Suma - Copy.dll
            //System.Web.Configuration.CompilationSection.LoadAssemblyHelper
            //var a = "https://bizagi-my.sharepoint.com/:u:/p/david_montoya/EUVzNV-QU3tFtrLmHo4TDqgBwWqnIjSX8dgWoBCPRs-wHw?e=COW8LF";
            //EditXmlFile();
            //RegexMatchRules();
            
            ChangeAssemblyInfoVersion("F:\\dv\\catalog",  version : "1.12.0.4");

            Console.ReadLine();
        }

        private static void ChangeAssemblyInfoVersion(string folderPath, string version)
        {
            var assemblyInfoFiles = System.IO.Directory.GetFiles(folderPath, "AssemblyInfo.cs", System.IO.SearchOption.AllDirectories);
            
            foreach (var assemblyInfoFile in assemblyInfoFiles)
            {
                var assemblyInfoContent = System.IO.File.ReadAllText(assemblyInfoFile);
                var modifiedContent = Regex.Replace(assemblyInfoContent, @"(?<=AssemblyVersion\("")\d+\.\d+\.\d+\.\d+(?=""\))", version);
                modifiedContent = Regex.Replace(assemblyInfoContent, @"(?<=AssemblyFileVersion\("")\d+\.\d+\.\d+\.\d+(?=""\))", version);
                System.IO.File.WriteAllText(assemblyInfoFile, modifiedContent);
            }
        }

        private static void EditXmlFile()
        {
            XmlDocument prvXmlDocto;
            XmlAttribute xmlAttKey;

            //open the XML file
            prvXmlDocto = new XmlDocument();
            prvXmlDocto.PreserveWhitespace = true;
            string fileName = "dm.config";
            prvXmlDocto.Load(fileName);

            XmlNode xmlNodeStart = prvXmlDocto.SelectSingleNode("//c");

            XmlNode newSub = prvXmlDocto.CreateNode(XmlNodeType.Element, "add", null);
            XmlAttribute xa = prvXmlDocto.CreateAttribute("key");
            xa.Value = "Project";
            newSub.Attributes.Append(xa);
            xmlNodeStart.AppendChild(newSub);

            //XmlNode id = xmlNodeStart.SelectSingleNode("//id");
            //id.Attributes["userName"] = "Tushar2";
            //id.SetAttribute("passWord", "Tushar2");
            //prvXmlDocto.AppendChild(id);

            //if (xmlNodeStart != null)
            //{
            //    //xmlAttKey = xmlNodeStart.Attributes["userName"];
            //    //xmlAttKey.Value = "dm";
            //    //xmlAttKey = xmlNodeStart.Attributes["password"];
            //    //xmlAttKey.Value = "dmpsw";
            //}

            var buffer = new StringBuilder();
            var writer = XmlWriter.Create(fileName, new XmlWriterSettings { Indent = true });
            prvXmlDocto.Save(writer);
            writer.Close();
        }

        private static void RegexMatchRules()
        {
            //var rule = "{\"displayName\":\"UX_ED_ComentariosPonencia\",\"description\":\"UX_ED_ComentariosPonencia\",\"ruleType\":\"Execution\",\"ruleCategory\":\"Boolean\",\"returnType\":\"None\",\"isReusable\":true,\"content\":\"//_11:Variables Declaration\\n\\n//__11\\n//_1:Expression\\nvar pasoPrimeraVez = Me.getXPath(\\\"m_CAT_TRAMITES.M_TRV_DatosGenerales.BPasoPrimerConcepto\\\");\\n{ref:0}.{ref:1}(Me,\\\"UX_ED_ComentariosPonencia\\\",\\\"Priema Vez\\\" + pasoPrimeraVez);\\nvar editable = false;\\n\\nif(<{xpath:0}> !=true){\\n\\neditable = true;\\n}\\n\\neditable;\\n//__1\",\"entity\":{\"baref\":{\"ref\":\"bb4c42da-3d76-4562-af4f-346da6b58078\"}},\"references\":[{\"baref\":{\"ref\":\"c5e21473-ea5e-4257-8436-da153ff24878\"}},{\"baref\":{\"ref\":\"4535095d-4d42-4a96-8ae9-ef43d5e84412\"}}],\"xpaths\":[{\"baxpath\":{\"xpath\":\"BRevisionPonencia\",\"contextentity\":\"bb4c42da-3d76-4562-af4f-346da6b58078\"}}]}";
            var rule = "{\"displayName\":\"CCC_SET_Completa2\",\"description\":\"\",\"ruleType\":\"Execution\",\"ruleCategory\":\"Scripting\",\"returnType\":\"None\",\"isReusable\":true,\"content\":\"//_11:Variables Declaration\\n\\n//__11\\n//_1:Expression\\nif(<{xpath:0}> == false || <{xpath:1}> == null){\\n\\tvar Preguntas = CHelper.GetValueAsCollection(Me.Context.getXPath(\\\"{xpath:2}\\\"));\\n\\tfor(var i = 0; i < Preguntas.size(); i++){\\n\\t\\tvar pregunta = Preguntas.get(i);\\n\\t\\tif(pregunta.getXPath(\\\"{xpath:3}\\\") != false){\\n\\t\\t\\tpregunta.setXPath(\\\"{xpath:4}\\\",false);\\n\\t\\t\\tvar Anexos = CHelper.GetValueAsCollection(pregunta.getXPath(\\\"{xpath:5}\\\"));\\n\\t\\t\\tfor(var j = 0; j < Anexos.size(); j++){\\n\\t\\t\\t\\tvar anexo = Anexos.get(j);\\n\\t\\t\\t\\tanexo.setXPath(\\\"{xpath:6}\\\",false);\\n\\t\\t\\t\\tanexo.setXPath(\\\"{xpath:7}\\\",null);\\n\\t\\t\\t}\\n\\t\\t}\\n\\t}\\n}else if(<{xpath:8}> == true){\\n\\tvar Preguntas = CHelper.GetValueAsCollection(Me.Context.getXPath(\\\"{xpath:9}\\\"));\\n\\tfor(var i = 0; i < Preguntas.size(); i++){\\n\\t\\tvar pregunta = Preguntas.get(i);\\n\\t\\tif(pregunta.getXPath(\\\"{xpath:10}\\\") != false){\\n\\t\\t\\tpregunta.setXPath(\\\"{xpath:11}\\\",false);\\n\\t\\t}\\n\\t}\\n}\\nif(<{xpath:12}> == true){\\n\\tvar Programas = CHelper.GetValueAsCollection(Me.Context.getXPath(\\\"{xpath:13}\\\"));\\n\\tfor(var j = 0; j < Programas.size(); j++){\\n\\t\\tvar programa = Programas.get(j);\\n\\t\\tprograma.setXPath(\\\"{xpath:14}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:15}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:16}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:17}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:18}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:19}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:20}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:21}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:22}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:23}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:24}\\\",false);\\n\\t\\tprograma.setXPath(\\\"{xpath:25}\\\",false);\\n\\t}\\n}\\n//__1\",\"entity\":{\"baref\":{\"ref\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},\"xpaths\":[{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.M_TRV_DatosGenerales.BPasoPrimerConcepto\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.M_TRV_DatosGenerales.BPasoPrimerConcepto\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.m_PRE_Master.M_PRE_Preguntass\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"bCuentaConInformacion\",\"contextentity\":\"1d710796-7623-4c34-aae9-057d144b801f\"}},{\"baxpath\":{\"xpath\":\"BCompleta\",\"contextentity\":\"1d710796-7623-4c34-aae9-057d144b801f\"}},{\"baxpath\":{\"xpath\":\"M_PRE_Anexoss\",\"contextentity\":\"1d710796-7623-4c34-aae9-057d144b801f\"}},{\"baxpath\":{\"xpath\":\"bCompleto\",\"contextentity\":\"4decc509-0e26-4338-9d53-5028c8af20d6\"}},{\"baxpath\":{\"xpath\":\"bAnexoRevisado\",\"contextentity\":\"4decc509-0e26-4338-9d53-5028c8af20d6\"}},{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.M_TRV_DatosGenerales.BPasoPrimerConcepto\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.m_PRE_Master.M_PRE_Preguntass\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"bCuentaConInformacion\",\"contextentity\":\"1d710796-7623-4c34-aae9-057d144b801f\"}},{\"baxpath\":{\"xpath\":\"BCompleta\",\"contextentity\":\"1d710796-7623-4c34-aae9-057d144b801f\"}},{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.BEsRadicado\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"m_CAT_TRAMITES.m_PRE_Master.m_PRE_IES_info.Programa\",\"contextentity\":\"299eee9b-6ad8-4875-8051-3132c4166325\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoInformacionProgr\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoCreditos\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoEscenarios\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoCiclos\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoCubrimiento\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoIdiomas\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoInformacionCont\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoDeclaracion\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoConceptualizacion\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoPerfil\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"M_TRV_AprobacionSala.bRevisoResultados\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}},{\"baxpath\":{\"xpath\":\"bRevRecRepo\",\"contextentity\":\"0a619b3a-b03a-4fda-a7ab-3da1df11643b\"}}]}";
            var code = "BPasoPrimerConcepto";
            Console.WriteLine(Regex.IsMatch(rule, $"(?i){code}") ? "Match" : "Not Match");
        }
    }
}
