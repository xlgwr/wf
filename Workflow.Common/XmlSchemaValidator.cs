using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;


namespace Workflow.Common
{
    /// <SUMMARY>
    /// This class validates an xml string or xml document against an xml
    /// schema.
    /// It has public methods that return a boolean value depending on 
    /// the validation
    /// of the xml.
    /// </SUMMARY>
    public class XmlSchemaValidator
    {
        private bool isValidXml = true;
        private string validationError = "";


        public XmlSchemaValidator()
        {

        }

        public String ValidationError
        {
            get
            {
                return "<VALIDATIONERROR>" + this.validationError
                       + "</VALIDATIONERROR>";
            }
            set
            {
                this.validationError = value;
            }
        }

        public bool IsValidXml
        {
            get
            {
                return this.isValidXml;
            }
        }

        private void ValidationCallBack(object sender,
                                   ValidationEventArgs args)
        {
            // The xml does not match the schema.
            isValidXml = false;
            this.ValidationError = args.Message;
        }


        public bool ValidXmlDoc(string xml,
               string schemaNamespace, string schemaUri)
        {
            try
            {
                if (xml == null || xml.Length < 1)
                {
                    return false;
                }

                StringReader srXml = new StringReader(xml);
                return ValidXmlDoc(srXml, schemaNamespace, schemaUri);
            }
            catch (Exception ex)
            {
                this.ValidationError = ex.Message;
                return false;
            }
        }

        public bool ValidXmlDoc(XmlDocument xml,
               string schemaNamespace, string schemaUri)
        {
            try
            {
                // Is the xml object valid?
                if (xml == null)
                {
                    return false;
                }

                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xml.WriteTo(xw);
                string strXml = sw.ToString();

                StringReader srXml = new StringReader(strXml);

                return ValidXmlDoc(srXml, schemaNamespace, schemaUri);
            }
            catch (Exception ex)
            {
                this.ValidationError = ex.Message;
                return false;
            }
        }

        public bool ValidXmlDoc(StringReader xml,
               string schemaNamespace, string schemaUri)
        {
            // Continue?
            if (xml == null || schemaNamespace == null || schemaUri == null)
            {
                return false;
            }

            isValidXml = true;
            XmlValidatingReader vr;
            XmlTextReader tr;
            XmlSchemaCollection schemaCol = new XmlSchemaCollection();
            //schemaCol.Add(schemaNamespace, schemaUri);

            try
            {
                tr = new XmlTextReader(xml);
                vr = new XmlValidatingReader(tr);
                vr.ValidationType = ValidationType.Auto;
                if (schemaCol != null)
                {
                    vr.Schemas.Add(schemaCol);
                }
                vr.ValidationEventHandler +=
                   new ValidationEventHandler(ValidationCallBack);
                while (vr.Read())
                {
                }

                vr.Close();

                return isValidXml;
            }
            catch (Exception ex)
            {
                this.ValidationError = ex.Message;
                return false;
            }
            finally
            {
                vr = null;
                tr = null;
            }
        }
    }
}
