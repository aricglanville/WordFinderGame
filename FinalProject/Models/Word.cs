﻿using System;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    public class Word
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public Meta meta { get; set; }
            public int hom { get; set; }
            public Hwi hwi { get; set; }
            public string fl { get; set; }
            public Def[] def { get; set; }
            public string[][] et { get; set; }
            public string date { get; set; }
            public string[] shortdef { get; set; }
            public In[] ins { get; set; }
            public Uro[] uros { get; set; }
            public Dro[] dros { get; set; }
        }

        public class Meta
        {
            public string id { get; set; }
            public string uuid { get; set; }
            public string sort { get; set; }
            public string src { get; set; }
            public string section { get; set; }
            public string[] stems { get; set; }
            public bool offensive { get; set; }
        }

        public class Hwi
        {
            public string hw { get; set; }
            public Pr[] prs { get; set; }
        }

        public class Pr
        {
            public string mw { get; set; }
            public Sound sound { get; set; }
        }

        public class Sound
        {
            public string audio { get; set; }
            public string _ref { get; set; }
            public string stat { get; set; }
        }

        public class Def
        {
            public object[][][] sseq { get; set; }
            public string vd { get; set; }
        }

        public class In
        {
            public string _if { get; set; }
            public string ifc { get; set; }
            public Pr1[] prs { get; set; }
        }

        public class Pr1
        {
            public string mw { get; set; }
            public Sound1 sound { get; set; }
        }

        public class Sound1
        {
            public string audio { get; set; }
            public string _ref { get; set; }
            public string stat { get; set; }
        }

        public class Uro
        {
            public string ure { get; set; }
            public Pr2[] prs { get; set; }
            public string fl { get; set; }
        }

        public class Pr2
        {
            public string mw { get; set; }
            public Sound2 sound { get; set; }
        }

        public class Sound2
        {
            public string audio { get; set; }
            public string _ref { get; set; }
            public string stat { get; set; }
        }

        public class Dro
        {
            public string drp { get; set; }
            public Vr[] vrs { get; set; }
            public Def1[] def { get; set; }
        }

        public class Vr
        {
            public string vl { get; set; }
            public string va { get; set; }
        }

        public class Def1
        {
            public object[][][] sseq { get; set; }
        }


    }
}

