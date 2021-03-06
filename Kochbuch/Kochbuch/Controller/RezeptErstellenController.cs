﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kochbuch
{
    class RezeptErstellenController
    {
        private static RezeptErstellenController instance;
        
        public static RezeptErstellenController getInstance()
        {
            if(instance == null)
            {
                instance = new RezeptErstellenController();
            }
            return instance;
        }
        public void ZutatBearbeiten(ZutatErstelltView erstelltView)
        {
            ZutatErstellenView erstellenView = RezeptErstellenView.getInstance().ZutatBearbeitenHinzufuegen();
            RezeptErstellenView.getInstance().ViewEntfernen(erstelltView);
            erstellenView.SetMenge(erstelltView.GetMenge());
            erstellenView.SetEinheit(erstelltView.GetEinheit());
            erstellenView.SetZutat(erstelltView.GetArt());
        }

        public void ZuatatHinzufuegen(ZutatErstellenView erstellenView)
        {
            ZutatErstelltView erstelltView = RezeptErstellenView.getInstance().ZutatHinzufuegen();
            erstelltView.SetMenge(erstellenView.GetMenge());
            erstelltView.SetEinheit(erstellenView.GetEinheit());
            erstelltView.SetZutat(erstellenView.GetZutat());
            RezeptErstellenView.getInstance().ViewEntfernen(erstellenView);
        }

        public async Task Speichern(RezeptErstellenView rezeptErstellenView, bool onlineSpeichern)
        {
            RezeptModel rezept = new RezeptModel();
            rezept.Titel = rezeptErstellenView.GetTitel();
            rezept.Schwierigkeit = rezeptErstellenView.GetSchwierigkeit();
            rezept.Beschreibung = rezeptErstellenView.GetBeschreibung();
            rezept.Autor = Application.Current.Properties["username"].ToString();
            rezept.Zutaten = new List<ZutatModel>();
            foreach(ZutatErstelltView zutat in rezeptErstellenView.GetZutatErstelltViews())
            {
                rezept.Zutaten.Add(new ZutatModel
                {
                    Menge = zutat.GetMenge(),
                    Einheit = zutat.GetEinheit(),
                    Art =zutat.GetArt()
                });
            }
            foreach (ZutatErstellenView zutat in rezeptErstellenView.GetZutatErstellenViews())
            {
                int menge = zutat.GetMenge();
                string einheit = zutat.GetEinheit();
                string art = zutat.GetZutat();
                if(art != "")
                {
                    rezept.Zutaten.Add(new ZutatModel
                    {
                        Menge = menge,
                        Einheit = einheit,
                        Art = art
                    });
                }
            }
            await LokalDb.GetInstance().SaveRezeptAsync(rezept);
            if(onlineSpeichern == true)
            {
                bool response = await OnlineDb.getInstance().SaveRezeptAsync(rezept);
                await OnlineRezepteController.getInstance().Refresh();
            }
            await EigeneRezepteController.getInstance().Refresh();
            await ÜbersichtController.getInstance().SetzeInhaltEigeneRezepte();
            RezeptErstellenView.getInstance().DatenLöschen();
        }
        
    }
}
