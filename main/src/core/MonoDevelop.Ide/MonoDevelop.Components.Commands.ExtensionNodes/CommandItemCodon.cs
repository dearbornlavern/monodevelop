//
// CommandItemCodon.cs
//
// Author:
//   Lluis Sanchez Gual
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using Mono.Addins;

namespace MonoDevelop.Components.Commands.ExtensionNodes
{
	[ExtensionNode (Description="A command menu or toolbar item. The id of the element must match the id of a registered command.")]
	internal class CommandItemCodon : InstanceExtensionNode
	{
		//these fields are assigned by reflection, suppress "never assigned" warning
		#pragma warning disable 649

		[NodeAttribute ("_label", "Label", Localizable=true)]
		string label;
		
		[NodeAttribute ("disabledVisible", "Visible when disabled")]
		bool disabledVisible = true;

		#pragma warning restore 649

		public override object CreateInstance ()
		{
			object id = CommandCodon.ParseCommandId (this);
			return new CommandEntry (id, label, disabledVisible);
		}
	}
}
