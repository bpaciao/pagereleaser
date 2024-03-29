﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;

namespace Jeebook.PageReleaser
{
    public class XHTMLResolver : XmlResolver
    {
        override public System.Net.ICredentials Credentials
        {
            set { }
        }

        public XHTMLResolver()
        {

        }

        public override Uri ResolveUri(Uri baseUri, String relativeUri)
        {
            if (String.Compare(relativeUri, "-//W3C//DTD XHTML 1.0 Transitional//EN", true) == 0)
            {
                return new Uri("http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd");
            }
            else if (String.Compare(relativeUri, "-//W3C//DTD XHTML 1.0 Transitional//EN", true) == 0)
            {
                return new Uri("http://www.w3.org/tr/xhtml1/DTD/xhtml1-strict.dtd");
            }
            else if (String.Compare(relativeUri, "-//W3C//DTD XHTML 1.0 Transitional//EN", true) == 0)
            {
                return new Uri("http://www.w3.org/tr/xhtml1/DTD/xhtml1-frameset.dtd");
            }
            else if (String.Compare(relativeUri, "-//W3C//DTD XHTML 1.1//EN", true) == 0)
            {
                return new Uri("http://www.w3.org/tr/xhtml11/DTD/xhtml11.dtd");
            }

            return base.ResolveUri(baseUri, relativeUri);
        }

        override public object GetEntity(Uri absoluteUri, string role,
            Type ofObjectToReturn)
        {
            Object entityObj = null;
            String strURI = absoluteUri.AbsoluteUri;
            System.IO.MemoryStream msStream = null;


            switch (strURI.ToLower())
            {
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd":
                    msStream = new MemoryStream(ResourceDTD.xhtml1_transitional);
                    break;
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml1.dcl":
                    msStream = new MemoryStream(ResourceDTD.xhtml1);
                    break;
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml-lat1.ent":
                    msStream = new MemoryStream(ResourceDTD.xhtml_lat1);
                    break;
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml-special.ent":
                    msStream = new MemoryStream(ResourceDTD.xhtml_special);
                    break;
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml-symbol.ent":
                    msStream = new MemoryStream(ResourceDTD.xhtml_symbol);
                    break;
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml1-strict.dtd":
                    msStream = new MemoryStream(ResourceDTD.xhtml1_strict);
                    break;
                case "http://www.w3.org/tr/xhtml1/dtd/xhtml1-frameset.dtd":
                    msStream = new MemoryStream(ResourceDTD.xhtml1_frameset);
                    break;
                case "http://www.w3.org/tr/xhtml11/dtd/xhtml11.dtd":
                    msStream = new MemoryStream(ResourceDTD.xhtml11);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-inlstyle-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_inlstyle_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-framework-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_framework_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-datatypes-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_datatypes_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-qname-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_qname_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-events-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_events_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-attribs-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_attribs_1);
                    break;
                case "http://www.w3.org/tr/xhtml11/dtd/xhtml11-model-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml11_model_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-charent-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_charent_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-lat1.ent":
                    msStream = new MemoryStream(ResourceDTD.xhtml_lat11);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-symbol.ent":
                    msStream = new MemoryStream(ResourceDTD.xhtml_symbol11);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-special.ent":
                    msStream = new MemoryStream(ResourceDTD.xhtml_special11);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-text-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_text_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-inlstruct-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_inlstruct_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-inlphras-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_inlphras_1);
                    break;
                case "http://www.w3.org/tr/ruby/xhtml-ruby-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_ruby_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-blkstruct-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_blkstruct_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-blkphras-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_blkphras_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-hypertext-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_hypertext_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-list-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_list_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-edit-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_edit_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-bdo-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_bdo_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-pres-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_pres_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-inlpres-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_inlpres_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-blkpres-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_blkpres_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-link-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_link_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-meta-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_meta_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-base-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_base_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-script-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_script_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-style-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_style_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-image-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_image_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-csismap-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_csismap_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-ssismap-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_ssismap_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-param-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_param_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-object-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_object_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-table-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_table_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-form-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_form_1);
                    break;
                case "http://www.w3.org/tr/xhtml-modularization/dtd/xhtml-struct-1.mod":
                    msStream = new MemoryStream(ResourceDTD.xhtml_struct_1);
                    break;
            }


            if (msStream != null)
            {
                entityObj = msStream;
            }
            else
            {
                XmlUrlResolver xur = new XmlUrlResolver();
                entityObj = xur.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
            return entityObj;
        }
    }
}