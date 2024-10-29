using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace BlazorWasmServerAuth.Client.Models {

	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class User {

		[JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 登录工号
		/// </summary>
		[JsonProperty, Column(Name = "code", DbType = "varchar(50)", IsNullable = false)]
		public string Code { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[JsonProperty, Column(Name = "name", StringLength = 50, IsNullable = false)]
		public string Name { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[JsonProperty, Column(Name = "password", DbType = "varchar(50)", IsNullable = false)]
		public string Password { get; set; }

	}

}
