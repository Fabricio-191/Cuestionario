using System;
using System.Collections.Generic; 

namespace Cuestionario {
	public class SymbolTable {
		public Dictionary<string, Parser.Type> variables = new Dictionary<string, Parser.Type>();
		
		Parser parser;
		
		public SymbolTable(Parser parser) {
			this.parser = parser;
			this.variables["score"] = Parser.Type.integer;
			this.variables["last_answer"] = Parser.Type.str;
		}

		public void setVariable(string name, Parser.Type type) {
			if(name == "score" || name == "last_answer") {
				parser.SemErr(name + " is a reserved variable");
				return;
			}
			variables[name] = type;
		}

		public Parser.Type getType(string name) {
			if (variables.ContainsKey(name)) {
				return variables[name];
			}
			
			parser.SemErr(name + " is undeclared");
		
			return 0; // undefined type
		}

	} // end SymbolTable
} // end namespace