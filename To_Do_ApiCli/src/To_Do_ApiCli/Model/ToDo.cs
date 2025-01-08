/*
 * To_Do_wpfweb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = To_Do_ApiCli.Client.OpenAPIDateConverter;

namespace To_Do_ApiCli.Model
{
    /// <summary>
    /// ToDo
    /// </summary>
    [DataContract(Name = "To_Do")]
    public partial class ToDo : IEquatable<ToDo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToDo" /> class.
        /// </summary>
        /// <param name="date">date.</param>
        /// <param name="plan">plan.</param>
        /// <param name="titleId">titleId.</param>
        public ToDo(DateTime date = default(DateTime), string plan = default(string), string titleId = default(string))
        {
            this.Date = date;
            this.Plan = plan;
            this.TitleId = titleId;
        }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or Sets Plan
        /// </summary>
        [DataMember(Name = "plan", EmitDefaultValue = true)]
        public string Plan { get; set; }

        /// <summary>
        /// Gets or Sets TitleId
        /// </summary>
        [DataMember(Name = "titleId", EmitDefaultValue = true)]
        public string TitleId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ToDo {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Plan: ").Append(Plan).Append("\n");
            sb.Append("  TitleId: ").Append(TitleId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ToDo);
        }

        /// <summary>
        /// Returns true if ToDo instances are equal
        /// </summary>
        /// <param name="input">Instance of ToDo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ToDo input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Plan == input.Plan ||
                    (this.Plan != null &&
                    this.Plan.Equals(input.Plan))
                ) && 
                (
                    this.TitleId == input.TitleId ||
                    (this.TitleId != null &&
                    this.TitleId.Equals(input.TitleId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Date != null)
                {
                    hashCode = (hashCode * 59) + this.Date.GetHashCode();
                }
                if (this.Plan != null)
                {
                    hashCode = (hashCode * 59) + this.Plan.GetHashCode();
                }
                if (this.TitleId != null)
                {
                    hashCode = (hashCode * 59) + this.TitleId.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}