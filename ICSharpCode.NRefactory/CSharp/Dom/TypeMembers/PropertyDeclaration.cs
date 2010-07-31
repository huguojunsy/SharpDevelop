// 
// PropertyDeclaration.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp
{
	
	public class Accessor : AbstractMember
	{
		public DomLocation Location {
			get;
			set;
		}
		
		public BlockStatement Body {
			get {
				return (BlockStatement)GetChildByRole (Roles.Body);
			}
		}
		
		public override S AcceptVisitor<T, S> (IDomVisitor<T, S> visitor, T data)
		{
			return visitor.VisitAccessorDeclaration (this, data);
		}
	}
	
	public class PropertyDeclaration : AbstractMember
	{
		public const int PropertyGetRole = 100;
		public const int PropertySetRole = 101;
		
		public CSharpTokenNode LBrace {
			get {
				return (CSharpTokenNode)GetChildByRole (Roles.LBrace);
			}
		}
		
		public CSharpTokenNode RBrace {
			get {
				return (CSharpTokenNode)GetChildByRole (Roles.RBrace);
			}
		}
		
		public Accessor GetAccessor {
			get {
				return (Accessor)GetChildByRole (PropertyGetRole);
			}
		}
		
		public Accessor SetAccessor {
			get {
				return (Accessor)GetChildByRole (PropertySetRole);
			}
		}
		
		public override S AcceptVisitor<T, S> (IDomVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPropertyDeclaration (this, data);
		}
	}
}
