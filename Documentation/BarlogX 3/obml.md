##Owl Binary Markup Language (OBML)
**OBML** was initially designed for the *Owl Project*, which is a communication security tool.

OBML is heavily inspired by EBML (part of MKV format, see [RFC Draft](http://matroska.org/technical/specs/rfc/index.html)).


###Variable Width Integers (VInt)
VInts are the foundation of OBML because all integer values are represented by VInts. Generally, the structure of a `OBML.VInt` is the same of that of `EBML.VInt` with an exception that `OBML.VInt` adds support for negative values. From this point on, `VInt` refers to the OBML version.

Every VInt consists of 4 parts: width indicator, separator, sign bit and value bits. 

####Width Indicator
The total width of a VInt is determined by the number of leading 0s. Each 0 adds 1 **byte** to the initial width of 1 byte. For example, a VInt starting with `1...` has the width of 1 byte; another VInt starting with `001...` has the width of 3 bytes.

####Separator
The first bit after width indicator is always 1, and it is called the separator.

####Sign Bit & Value Bits
All bits after the separator are used for storing value. They are formatted exactly the same as usual integers, with the only difference being non-standard bit sizes. For example, for a VInt starting with `1...`, the width of its value is 7 bits; for a VInt starting with `001...`, the width of its value is 21 bits. All widths include the sign bit.

For additional information, please refer to the implementation of [`libWyvernzora.Core.VInt`](https://github.com/jluchiji/libWyvernzora/blob/master/libWyvernzora/Core/VInt.cs).

###OBML Node
An OBML file consists of numerous nodes, nested in a fashion similar to XML. Structure of a node is as follows:

	ObmlNode {

		VInt		Node ID
		VInt		Child Count
		VInt		Data Length
		
		ObmlNode*	Children
		Byte*		Data	

	}