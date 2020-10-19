# TCP-Component
Easy to Use TCP Component<br>
1.動機<br>
&nbsp;&nbsp;&nbsp;&nbsp;攥寫 TCP IP 的通訊程式，對於新手來說，並不友善。即使是資深的程式設計員，
對於不斷的需要宣告 delegate，event，以及Invoke，CallBack，Async 等，亦會
覺得不耐煩，故已經有許多前輩寫出精采 TCP Model ，可以降低入門門檻，可以不需要處理繁雜的Callback程序，
但依然有一些問題，大部分的模組，只適用於 Console mode，運用於 Windows Form 時，依然
要自己處理Invok，因為CallBack等同使用另一個執行緒傳回內容，若不適當處理無法用於 Windows Form。
另一個問題是部分攥寫者使用同步傳送，以減少CallBack的使用，但是此寫法會占用整個執行緒，使得使用者
介面響應不佳，全程使用非同步傳送是較好的選擇。基於上述兩個問題，筆者已將TCP 程序包裝成元件，
且將回傳值，拉回了使用者介面執行緒。這使得使用TCP IP 就像使用 Windows Form 中的 Button 一樣簡單。
TCP IP 的另一個課題是，高於第三層的通訊協定，往往是一個head struct，與複雜的內容Struct，而TCP IP 傳送的是 BYTE[]，
未來也會提供將 Struct' byte[] 互轉的函數，使用者將不在需要了解 typeof 等技術，而可以傳送高於第三層的網路協定。
2.
