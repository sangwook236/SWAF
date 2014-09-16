using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.Core
{
    using System.Runtime.CompilerServices;

    public class DesignByContract
    {
        public static void throwPreconditionError(bool predicate, string message, [CallerMemberName] string member = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = -1)
        {
            if (!predicate) throw new PreconditionViolation(message, member, file, line);
        }

        public static void throwPostconditionError(bool predicate, string message, [CallerMemberName] string member = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = -1)
        {
            if (!predicate) throw new PostconditionViolation(message, member, file, line);
        }

        public static void throwInvariantError(bool predicate, string message, [CallerMemberName] string member = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = -1)
        {
            if (!predicate) throw new InvariantViolation(message, member, file, line);
        }

        public static void throwRuntimeError(string message, [CallerMemberName] string member = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = -1)
        {
            throw new ContractViolation("Run-time violation!", message, member, file, line);
        }
    }
    
    public class ContractViolation: Exception
    {
        public ContractViolation(string prefix, string message, string member, string file, int line)
        : base(prefix + " - " + message + ", (" + member + ", " + file + ':' + line + ')')
	    {}

        public ContractViolation(string prefix, string message)
        : base(prefix + " - " + message)
	    {}
    }

    class PreconditionViolation : ContractViolation
    {
	    public PreconditionViolation(string message, string member, string file, int line)
	    : base("Precondition violation!", message, member, file, line)
	    {}

	    public PreconditionViolation(string message)
        : base("Precondition violation!", message)
	    {}
    }

    class PostconditionViolation : ContractViolation
    {
	    public PostconditionViolation(string message, string member, string file, int line)
	    : base("Postcondition violation!", message, member, file, line)
	    {}

	    public PostconditionViolation(string message)
	    : base("Postcondition violation!", message)
	    {}
    }

    class InvariantViolation : ContractViolation
    {
	    public InvariantViolation(string message, string member, string file, int line)
	    : base("Invariant violation!", message, member, file, line)
	    {}

	    public InvariantViolation(string message)
        : base("Invariant violation!", message)
	    {}
    }
}
