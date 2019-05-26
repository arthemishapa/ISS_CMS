using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ScheduledJobs
{
    public class EmailTemplateRenderer
    {
        public static string RenderEmailTemplate(string templateName, dynamic model)
        {
            var logoUrl = "http://localhost:64140/Content/photos/logo.PNG";

            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var templateFolderPath = Path.Combine(basePath, "Views\\Shared\\DisplayTemplates");

            var templateLayout = Path.Combine(templateFolderPath, "Layout.cshtml");
            var templateFile = Path.Combine(templateFolderPath, templateName + ".cshtml");
            var templateHeader = Path.Combine(templateFolderPath, "Header.cshtml");
            var templateFooter = Path.Combine(templateFolderPath, "Footer.cshtml");

            var service = Engine.Razor;

            var emailTemplate = File.ReadAllText(templateFile);
            var layoutTemplate = File.ReadAllText(templateLayout);
            var headerTemplate = File.ReadAllText(templateHeader);
            var footerTemplate = File.ReadAllText(templateFooter);

            var compiledFooter = service.RunCompile(footerTemplate, footerTemplate, null, new { Url = logoUrl });

            service.AddTemplate("Header", headerTemplate);
            service.AddTemplate("Footer", compiledFooter);
            service.AddTemplate("Layout", layoutTemplate);

            return service.RunCompile(emailTemplate, emailTemplate, null, (object)model);
        }
    }
}