using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.Utiles.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString HelperMenu(this HtmlHelper helper, List<Opcion> listaOpciones, string titulo)
        {
            //elaborado por pepr y david
            //TagBuilder tbPrincipal = new TagBuilder("ul");
            //tbPrincipal.AddCssClass("sidebar-menu");
            //tbPrincipal.Attributes.Add("data-widget", "tree");

            //var liHeader = new TagBuilder("li");
            //liHeader.AddCssClass("header");
            ////   liHeader.InnerHtml = "MENU DE OPCIONES";
            //liHeader.InnerHtml = titulo;
            //tbPrincipal.InnerHtml += liHeader.ToString();

            //if (listaOpciones == null || listaOpciones.Count() == 0)
            //{
            //    return new MvcHtmlString(tbPrincipal.ToString());
            //}
            //bool tieneHijo = false;


            //if ((VariablesWeb.gOpciones != null))
            //{
            //    foreach (Opcion item in (from x in VariablesWeb.gOpciones where x.IdOpcionRef == 0 select x).ToList())
            //    {
            //        tieneHijo = listaOpciones.Where(t => t.IdOpcionRef == item.IdOpcion).Any();

            //        TagBuilder tbCero = new TagBuilder("li");
            //        if (tieneHijo)
            //        {
            //            tbCero.AddCssClass("treeview");
            //        }

            //        TagBuilder tcHrefCero = new TagBuilder("a");
            //        tcHrefCero.Attributes.Add("href", item.UrlOpcion);

            //        var iLista = new TagBuilder("i");
            //        iLista.AddCssClass(item.RutaImagen);
            //        tcHrefCero.InnerHtml += iLista.ToString();

            //        var spanLista = new TagBuilder("span");
            //        spanLista.InnerHtml = item.NombreOpcion;
            //        tcHrefCero.InnerHtml += spanLista;

            //        if (tieneHijo)
            //        {
            //            var spanhijo = new TagBuilder("span");
            //            spanhijo.AddCssClass("pull-right-container");

            //            var iHijo = new TagBuilder("i");
            //            iHijo.AddCssClass("fa fa-angle-left pull-right");
            //            spanhijo.InnerHtml += iHijo.ToString();
            //            tcHrefCero.InnerHtml += spanhijo;
            //        }


            //        //tcHrefCero.InnerHtml = item.NombreOpcion;
            //        tbCero.InnerHtml = tcHrefCero.ToString(); // amarra


            //        //tcHrefCero.InnerHtml += tcHrefCero;




            //TagBuilder tbSemiPrincipal = new TagBuilder("ul"); tbSemiPrincipal.AddCssClass("treeview-menu");
            //if ((from y in VariablesWeb.gOpciones where y.IdOpcionRef == item.IdOpcion select y).Count() > 0)
            //        {
            //            bool tieneNieto = false;

            //foreach (Opcion itemHijo in (from y in VariablesWeb.gOpciones where y.IdOpcionRef == item.IdOpcion select y).ToList())
            //{
            // tieneNieto = listaOpciones.Where(t => t.IdOpcionRef == itemHijo.IdOpcion).Any();

            //TagBuilder tbUno = new TagBuilder("li");
            //if (tieneNieto)
            //{
            // tbUno.AddCssClass("treeview");
            //}

            //TagBuilder tbHrefUno = new TagBuilder("a");
            //tbHrefUno.Attributes.Add("href", itemHijo.UrlOpcion);


            //var iLista1 = new TagBuilder("i");
            //iLista1.AddCssClass("fa fa-share");
            //tbHrefUno.InnerHtml += iLista1.ToString();

            //var spanLista1 = new TagBuilder("span");
            //spanLista1.InnerHtml = itemHijo.NombreOpcion;
            //tbHrefUno.InnerHtml += spanLista1;

            //if (tieneNieto)
            //{
            //  var spanhijo1 = new TagBuilder("span");
            //  spanhijo1.AddCssClass("pull-right-container");

            //  var iHijo1 = new TagBuilder("i");
            // iHijo1.AddCssClass("fa fa-angle-left pull-right");
            // spanhijo1.InnerHtml += iHijo1.ToString();
            // tbHrefUno.InnerHtml += spanhijo1;
            //}



            // //tbHrefUno.InnerHtml = itemHijo.NombreOpcion;
            //tbUno.InnerHtml = tbHrefUno.ToString(); //amarra 




            // //otros sub niveles
            // TagBuilder tbSemiSemiPrincipal = new TagBuilder("ul"); tbSemiSemiPrincipal.AddCssClass("treeview-menu");
            //if ((from z in VariablesWeb.gOpciones where z.IdOpcionRef == itemHijo.IdOpcion select z).Count() > 0)
            //{
            //foreach (Opcion itemNieto in (from z in VariablesWeb.gOpciones where z.IdOpcionRef == itemHijo.IdOpcion select z).ToList())
            //{
            //TagBuilder tbDos = new TagBuilder("li");
            //tbDos.AddCssClass("treeview");

            //TagBuilder tbHrefDos = new TagBuilder("a");
            //tbHrefDos.Attributes.Add("href", itemNieto.UrlOpcion);

            //var iLista2 = new TagBuilder("i");
            //iLista2.AddCssClass("fa fa-circle-o");
            //tbHrefDos.InnerHtml += iLista2.ToString();


            //var spanLista2 = new TagBuilder("span");
            //spanLista2.InnerHtml = itemNieto.NombreOpcion;
            //tbHrefDos.InnerHtml += spanLista2;



            ////tbHrefDos.InnerHtml = itemNieto.NombreOpcion;
            //tbDos.InnerHtml = tbHrefDos.ToString(); //amarra 

            //tbSemiSemiPrincipal.InnerHtml += tbDos.ToString();
            //}
            //tbUno.AddCssClass("treeview");
            //tbUno.InnerHtml += tbSemiSemiPrincipal.ToString();

            //}
            ////////////
            //tbSemiPrincipal.InnerHtml += tbUno.ToString();

            //}
            //tbCero.AddCssClass("treeview");
            //tbCero.InnerHtml += tbSemiPrincipal.ToString();

            //}
            //tbPrincipal.InnerHtml += tbCero.ToString();


            //}
            //}

            //return new MvcHtmlString(tbPrincipal.ToString());




            //elaboradopor Miguel.

            //var principal = new TagBuilder("ul");
            //principal.AddCssClass("sidebar-menu");
            //principal.Attributes.Add("data-widget", "tree");

            //var liHeader = new TagBuilder("li");
            //liHeader.AddCssClass("header");
            //liHeader.InnerHtml = titulo;
            //principal.InnerHtml += liHeader.ToString();

            //if (listaOpciones == null || listaOpciones.Count() == 0)
            //{
            //return new MvcHtmlString(principal.ToString());
            //}
            //bool tieneHijo = false;

            //foreach (Opcion item in listaOpciones .Where(t => t.IdOpcionRef == 0) .OrderBy(r =>r.NroOrden).ToList())
            //{
            //tieneHijo = listaOpciones.Where(t => t.IdOpcionRef == item.IdOpcion).Any();

            //var itemLista = new TagBuilder("li");
            //if (tieneHijo)
            // {
            //   itemLista.AddCssClass("treeview");
            //}

            //var linkLista = new TagBuilder("a");
            //linkLista.Attributes["href"] = GeneraHRef(helper, item);

            //var iLista = new TagBuilder("i");
            //iLista.AddCssClass(item.RutaImagen);
            //linkLista.InnerHtml += iLista.ToString();

            //var spanLista = new TagBuilder("span");
            //spanLista.InnerHtml = item.NombreOpcion;
            //linkLista.InnerHtml += spanLista;

            //if (tieneHijo)
            //{
            // var spanHijo = new TagBuilder("span");
            // spanHijo.AddCssClass("pull-right-container");

            // var iHijo = new TagBuilder("i");
            // iHijo.AddCssClass("fa fa-angle-left pull-right");
            // spanHijo.InnerHtml += iHijo.ToString();

            // linkLista.InnerHtml += spanHijo;
            // }

            // //llenar los menus hijo


            // itemLista.InnerHtml += linkLista.ToString();
            // principal.InnerHtml += itemLista.ToString();
            //}

            //return new MvcHtmlString(principal.ToString());

            //.................................................
            // final eleaborado por miguel recursivo
            //////////////////////////////////////////////////
            var principal = new TagBuilder("ul");
            principal.AddCssClass("sidebar-menu");
            principal.Attributes.Add("data-widget", "tree");

            var liHeader = new TagBuilder("li");
            liHeader.AddCssClass("header");
            liHeader.InnerHtml = titulo;
            principal.InnerHtml += liHeader.ToString();

            if (listaOpciones == null || listaOpciones.Count() == 0)
            {
                return new MvcHtmlString(principal.ToString());
            }
            bool tieneHijo = false;

            foreach (Opcion item in listaOpciones
                .Where(t => t.IdOpcionRef == 0)
                .OrderBy(r => r.NroOrden).ToList())
            {
                tieneHijo = listaOpciones.Where(t => t.IdOpcionRef == item.IdOpcion).Any();

                var itemLista = new TagBuilder("li");
                if (tieneHijo)
                {
                    itemLista.AddCssClass("treeview");
                }

                var linkLista = new TagBuilder("a");
                linkLista.Attributes["href"] = GeneraHRef(helper, item);

                var iLista = new TagBuilder("i");
                iLista.AddCssClass(item.RutaImagen);
                linkLista.InnerHtml += iLista.ToString();

                var spanLista = new TagBuilder("span");
                spanLista.InnerHtml = item.NombreOpcion;
                linkLista.InnerHtml += spanLista;

                if (tieneHijo)
                {
                    var spanHijo = new TagBuilder("span");
                    spanHijo.AddCssClass("pull-right-container");

                    var iHijo = new TagBuilder("i");
                    iHijo.AddCssClass("fa fa-angle-left pull-right");
                    spanHijo.InnerHtml += iHijo.ToString();

                    linkLista.InnerHtml += spanHijo;
                }


                itemLista.InnerHtml += linkLista.ToString();
                if (tieneHijo)
                {
                    LlenarOpcionMenu(itemLista, item, listaOpciones, helper);
                }


                principal.InnerHtml += itemLista.ToString();
            }

            return new MvcHtmlString(principal.ToString());


        }

        //  Lazy patre recursiva del menu
        private static void LlenarOpcionMenu(TagBuilder itemLista, Opcion item, List<Opcion> listaOpciones, HtmlHelper helper)
        {
            var ulHijo = new TagBuilder("ul");
            ulHijo.AddCssClass("treeview-menu");

            foreach (Opcion itemOpcion in (from x in listaOpciones
                                           where x.IdOpcionRef == item.IdOpcion
                                           select x).ToList())
            {

                bool tieneHijo = (from x in listaOpciones
                                  where x.IdOpcionRef == itemOpcion.IdOpcion
                                  select x).Any();

                var liHijo = new TagBuilder("li");
                if (tieneHijo)
                {
                    liHijo.AddCssClass("treeview");
                }

                var aHijo = new TagBuilder("a");
                aHijo.Attributes["href"] = GeneraHRef(helper, itemOpcion);

                var iHijo = new TagBuilder("i");
                iHijo.AddCssClass(itemOpcion.RutaImagen);
                aHijo.InnerHtml += iHijo;

                aHijo.InnerHtml += itemOpcion.NombreOpcion;

                if (tieneHijo)
                {
                    var spanHijo = new TagBuilder("span");
                    spanHijo.AddCssClass("pull-right-container");

                    var iHijo2 = new TagBuilder("i");
                    iHijo2.AddCssClass("fa fa-angle-left pull-right");
                    spanHijo.InnerHtml += iHijo2.ToString();

                    aHijo.InnerHtml += spanHijo;
                }

                liHijo.InnerHtml += aHijo.ToString();

                if (tieneHijo)
                {
                    LlenarOpcionMenu(liHijo, itemOpcion, listaOpciones, helper);
                }

                ulHijo.InnerHtml += liHijo.ToString();

            }

            itemLista.InnerHtml += ulHijo.ToString();


        }


        private static string GeneraHRef(HtmlHelper helper, Opcion item)
        {
            string rutaUrl = string.Empty;
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            if (!string.IsNullOrEmpty(item.UrlOpcion) && item.UrlOpcion != "#")
            {
                string[] ruta = item.UrlOpcion.Split('/');
                switch (ruta.Count())
                {
                    case 1:
                        rutaUrl = urlHelper.Action("Index", ruta[0]);
                        break;
                    case 2:
                        if (ruta[1].Split('?').Count() > 1)
                        {
                            rutaUrl = urlHelper.Action(ruta[1].Split('?')[0], ruta[0], RetornaObjetoParametros(ruta[1].Split('?')[1]));
                        }
                        else
                        {
                            rutaUrl = urlHelper.Action(ruta[1], ruta[0]);
                        }

                        break;
                    case 3:
                        if (ruta[2].Split('?').Count() > 1)
                        {
                            rutaUrl = urlHelper.Action(ruta[2].Split('?')[0], ruta[0] + "/" + ruta[1], RetornaObjetoParametros(ruta[2].Split('?')[1]));
                        }
                        else
                        {
                            rutaUrl = urlHelper.Action(ruta[2], ruta[0] + "/" + ruta[1]);
                        }

                        break;
                    default:
                        rutaUrl = item.UrlOpcion;
                        break;
                }

            }
            else
            {
                rutaUrl = "#";
            }

            return rutaUrl;

        }
        private static RouteValueDictionary RetornaObjetoParametros(string parametro)
        {
            RouteValueDictionary rvd = new RouteValueDictionary();

            string[] parametros = parametro.Split('&');
            Dictionary<string, string> lista = new Dictionary<string, string>();
            foreach (string item in parametros)
            {
                rvd.Add(item.Split('=')[0], item.Split('=')[1]);
                //lista.Add(item.Split('=')[0], item.Split('=')[1]);
            }
            return rvd;
        }
    }
}
