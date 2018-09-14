using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MainModel
    {
		[DisplayName("Text")]
		public string Text {
			get; set;
		}

		[DisplayName("Lemmatized text")]
		public string LemmatizedText {
			get; set;
		}
	}
}
