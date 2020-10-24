# TCP-Component
Easy to Use TCP Component</br>
1.動機</br>
&nbsp;&nbsp;&nbsp;&nbsp;攥寫 TCP IP 的通訊程式，對於新手來說，並不友善。即使是資深的程式設計員，
對於不斷的需要宣告 delegate，event，以及Invoke，CallBack，Async 等，亦會
覺得不耐煩，故已經有許多前輩寫出精采 TCP Model ，可以降低入門門檻，可以不需要處理繁雜的Callback程序，
但依然有一些問題，大部分的模組，只適用於 Console mode，運用於 Windows Form 時，依然
要自己處理Invok，因為CallBack等同使用另一個執行緒傳回內容，若不適當處理無法用於 Windows Form。
另一個問題是部分攥寫者使用同步傳送，以減少CallBack的使用，但是此寫法會占用整個執行緒，使得使用者
介面響應不佳且無法達到多使用者連結，全程使用非同步傳送是較好的選擇。基於上述兩個問題，筆者已將TCP 程序包裝成元件，
且將回傳值，拉回了使用者介面執行緒。這使得使用TCP IP 就像使用 Windows Form 中的 Button 一樣簡單。
TCP IP 的另一個課題是，高於第三層的通訊協定，往往是一個head struct，與複雜的內容Struct，而TCP IP 傳送的是 BYTE[]，
未來也會提供將 Struct， byte[] 互轉的函數，使用者將不在需要了解 typeof 等技術，而可以傳送高於第三層的網路協定。</br>
&nbsp;&nbsp;&nbsp;&nbsp; Writing a TCP IP communication program is not friendly for novices. Even experienced programmers,
For the constant need to declare delegate, event, and Invoke, CallBack, Async, etc., it will also
feeled impatient, so many predecessors have written brilliant TCP Models, which can lower the entry barrier and eliminate the need to deal with complicated Callback procedures.
But there are still some problems. Most of the modules are only applicable to Console mode. When used in Windows Form, they still
You have to handle Invok yourself, because CallBack is equivalent to using another thread to return content, and it cannot be used in Windows Form if it is not handled properly.
Another problem is that some writers use synchronous transmission to reduce the use of CallBack, but this way of writing will occupy the entire thread, making users
The interface is not responsive and also can not do multiple connections, and it is better to use asynchronous transmission throughout the process. Based on the above two problems, the author has packaged the TCP program into components,
And the return value is pulled back to the user interface thread. This makes using TCP IP as easy as using Button in Windows Form.
Another issue of TCP IP is that the communication protocol higher than the third layer is often a head struct with complex content Struct, while TCP IP transmits BYTE[],
In the future, a function to convert Struct' byte[] will also be provided. Users will no longer need to understand technology such as typeof, but can transmit network protocols higher than the third layer.


2.How to use in window Form <br>
  a.)download CT_TCP_Library.dll and Ct_TCP_Conreol.dll file .<br>
  b.)click  mouse right on tools box and slect  "select item" of tools box .<br>
  c.)click browse  and select download file which is CT_TCP_Library.dll and Ct_TCP_Conreol.dll.<br>
  d.)you will see a new controler on tools boxs.<br>
  e.)pull control item to form .<br>
  f.)now ,can use event to send data or revice data. and do not need any Invoke or callback.<br>
