# 实现HTML的简单压缩 #

[PageReleaser](http://www.mytools360.com)需要一种HTML的压缩算法，Google了很久，发现如果只是简单去除空白和注释的话，使用XLinq就可以轻易的实现

先看看MSDN是怎么说的：

一种常用方案是读取缩进的 XML，在内存中创建一个没有任何空白文本节点（即不保留空白）的 XML 树，对该 XML 执行某些操作，然后保存带缩进的 XML。在序列化带格式的 XML 时，只保留 XML 树中有意义的空白。这是 LINQ to XML 的默认行为。

另一个常见的情况是读取和修改已经有意缩进的 XML。您可能不想以任何方式更改这种缩进。若要在 LINQ to XML 中执行此操作，您要在加载或解析 XML 时保留空白，并在序列化 XML 时禁用格式设置。

简单的说，XDocument载入时，默认使用LoadOptions::None，自动去掉XML的空白；保存时，默认使用SaveOptions::None，自动格式化XML。

也就是说，使用XDocument将一个HTML文档打开什么也不作就保存，其实等于实现了HTML的格式化。

而如果在保存时，使用SaveOptions::DisableFormatting参数，看似要保存XML的空白，由于载入时所有空白都被删掉了，其实等于删除了所有空白，于是去掉空白就这样实现了。

至于删掉注释也很简单，只是需要注意，一般页面嵌入JavaScript会使用注释节点包裹，需要例外处理。

整个HTML压缩代码如下：

```
var nodes = from s in doc.DescendantNodes() 
           where s.NodeType == XmlNodeType.Comment && 
           string.Compare( s.Parent.Name.LocalName, "script", true ) != 0 
           select s; 

nodes.Remove(); 
doc.Save( sm.OutputPath + "index.html", SaveOptions.DisableFormatting );
```

简单吧，不过HTML不能直接使用XML解析器，需要预先转换为XHTML，[点击](http://jeebook.com/blog/?p=606,)察看转换实现。