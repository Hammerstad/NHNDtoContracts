﻿using NHN.DtoContracts.Common.en;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Htk;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Dette representerer en fastlegeavtale og implisitt en fastlegeliste.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    [Serializable]
    public class GPContract
    {
        /// <summary>
        /// This ID is owned by and set by FLO. Must be a positive integer.
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Hvorvidt listen er en del av en "Fellesliste".
        /// </summary>
        [DataMember]
        public bool ParticipatesOnCommonList { get; set; }

        /// <summary>
        /// Hvorvidt listen er en del av "gruppepraksis".
        /// </summary>
        [DataMember]
        public bool GroupGPOffice { get; set; }

        /// <summary>
        /// Hvorvidt dette er en fastlønnet avtale.
        /// </summary>
        [DataMember]
        public bool IsFixedSalary { get; set; }

        /// <summary>
        /// Hvis det kreves medlemskap for være på en liste, så er innholdet av RequiresMembership satt til ID'en for dette medlemskapet. 
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_membership">flrv2_membership</see> (OID 7755).
        /// </summary>
        [DataMember]
        public Code RequiresMembership { get; set; }

        /// <summary>
        /// Legekontor.
        /// Orgnummeret vil en finne i Adresseregisteret og eventuelt RESH. Denne SKAL være NULL ved skriving, og vil være satt ved lesing når det er relevant.
        /// </summary>
        [DataMember]
        public Business GPOffice { get; set; }

        /// <summary>
        /// Brukes ved skriving. Vil være satt ved lesing, og vil ha samme verdi som GPOffice.OrganizationNumber
        /// </summary>
        [DataMember]
        public int GPOfficeOrganizationNumber { get; set; }

        /// <summary>
        /// Listetak. Det maksimalt antallet pasienter som kan være på en liste under normale omstendigheter. I visse tilfeller vil listetaket kunne overskrides.
        /// </summary>
        [DataMember]
        public int MaxPatients { get; set; }

        /// <summary>
        /// Listestatus. Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_statuscode">flrv2_statuscode</see> (OID 7751).
        /// </summary>
        [DataMember]
        public Code Status { get; set; }

        /// <summary>
        /// Navn på listen, brukt ifbm. felleslister. ??? Trenger vi dette?
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Når avtalen ble opprettet.
        /// </summary>
        [DataMember]
        public DateTime AgreementDate { get; set; }

        /// <summary>
        /// Gyldighetsperiode for avtalen.
        /// </summary>
        [DataMember]
        public Period Valid { get; set; } // FraDato; ?TilDato;

        /// <summary>
        /// Legetilknytninger.
        /// </summary>
        [DataMember]
        public IList<GPOnContractAssociation> DoctorCycles { get; set; }

        /// <summary>
        /// Liste over utekontor for denne listen.
        /// </summary>
        [DataMember]
        public IList<OutOfOfficeLocation> OutOfOfficeOffices { get; set; }

        /// <summary>
        /// Pasienter som er koblet til denne kontrakten
        /// </summary>
        [DataMember]
        public IList<PatientToGPContractAssociation> PatientList { get; set; }

        /// <summary>
        /// Kommune. Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/kommune">kommune</see> (OID 3402).
        /// </summary>
        [DataMember]
        public Code Municipality { get; set; }

        /// <summary>
        /// Kommuner som samarbeider med hovedkommunen på denne kontrakten.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/kommune">kommune</see> (OID 3402).
        /// </summary>
        [DataMember]
        public IList<Code> CoopMunicipalities { get; set; }

        /// <summary>
        /// Bydel. Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/bydel">bydel</see> (OID 3403).
        /// </summary>
        [DataMember]
        public Code District { get; set; }

        /// <summary>
        /// Avslutningsårsak. 
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_contract_endreason">flrv2_contract_endreason</see> (OID 7753).
        /// </summary>
        [DataMember]
        public Code EndReason { get; set; }

        /// <summary>
        /// Tidspunkt data ble sist oppdatert
        /// </summary>
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}