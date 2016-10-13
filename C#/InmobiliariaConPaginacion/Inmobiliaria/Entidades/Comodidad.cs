using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Comodidad
    {
        int dormitorios;
        int baños;
        Boolean amueblado;
        Boolean heladera;
        Boolean internet;
        Boolean equipamientoCocina;
        Boolean microondas;
        Boolean tvCable;
        Boolean parrillero;
        Boolean estufaALeña;
        Boolean estacionamiento;
        Boolean piscina;

        int id;
        public int Id
        {
            get { return id; }

        }

        public int Dormitorios
        {
            get { return dormitorios; }
            set { dormitorios = value; }
        }
        public int Baños
        {
            get { return baños; }
            set { baños = value; }
        }
        public Boolean Amueblado
        {
            get { return amueblado; }
            set { amueblado = value; }
        }
        public Boolean Heladera 
        {
            get { return heladera; }
            set { heladera = value; }
        }
        public Boolean Internet
        {
            get { return internet; }
            set { internet = value; }
        }
        public Boolean EquipamientoCocina
        {
            get { return equipamientoCocina; }
            set { equipamientoCocina = value; }
        }
        public Boolean Microondas
        {
            get { return microondas; }
            set { microondas = value; }
        }
        public Boolean TvCable
        {
            get { return tvCable; }
            set { tvCable = value; }
        }
        public Boolean Parrillero
        {
            get { return parrillero; }
            set { parrillero = value; }
        }
        public Boolean EstufaALeña
        {
            get { return estufaALeña; }
            set { estufaALeña = value; }
        }
        public Boolean Estacionamiento
        {
            get { return estacionamiento; }
            set { estacionamiento = value; }
        }
        public Boolean Piscina
        {
            get { return piscina; }
            set { piscina = value; }
        }

        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Comodidad()
        { 
        }

        /// <summary>
        /// Constructor que ya deja seteados los valores de las distintas comodidades
        /// </summary>
        /// <param name="cDrmitorios">Cantidad de dormitorios</param>
        /// <param name="cAmueblado">¿Esta amueblado?</param>
        /// <param name="cHeladera">¿Tiene heladera?</param>
        /// <param name="cInternet">¿Tiene internet?</param>
        /// <param name="cEquipamientoCocina">¿Tiene equipamiento para la cocina?</param>
        /// <param name="cMicroondas">¿Tiene microondas?</param>
        /// <param name="cTvCable">¿Tiene tv cable?</param>
        /// <param name="cParrillero">¿Tiene parrillero?</param>
        /// <param name="cEstufaALeña">¿Tiene estufa a leña?</param>
        /// <param name="cEstacionamiento">¿Tiene estacionamiento?</param>
        /// <param name="cPiscina">¿Tiene piscina?</param>
        public Comodidad(int cDrmitorios, Boolean cAmueblado, Boolean cHeladera,Boolean cInternet, 
                         Boolean cEquipamientoCocina,Boolean cMicroondas,Boolean cTvCable,Boolean cParrillero,
                         Boolean cEstufaALeña,Boolean cEstacionamiento,Boolean cPiscina, int cBaños)
        {
            this.dormitorios=cDrmitorios;
            this.amueblado=cAmueblado;
            this.heladera=cHeladera;
            this.internet=cInternet;
            this.equipamientoCocina=cEquipamientoCocina;
            this.microondas=cMicroondas;
            this.tvCable=cTvCable;
            this.parrillero=cParrillero;
            this.estufaALeña=cEstufaALeña;
            this.estacionamiento=cEstacionamiento;
            this.piscina=cPiscina;
            this.baños = cBaños;
        }
    }
}