# Antarmuka dari Dialog “Buat Projek Baru”

## 1.. Antarmuka Grafis Utama


## 2. Komponen dalam antarmuka

| Property | Type |
|----|----|
| Name | TextBox |
| Description | RichTextbox |
| Visibility | DropDown |
| Make Deadline | CheckBox |
| Deadline | DateTimePicker |
| Banner Image | FilePicker |

## 3. Aturan Antarmuka


1. Saat dialog muncul, pemilih tanggal "**Deadline**" secara default tidak terlihat, dan hanya terlihat, tersedia, dan diterapkan jika kotak centang "**Make Deadline**" dicentang.
2. Izinkan pengguna untuk menggunakan Format MarkDown di dalam RichTextBox "**Description**" untuk menyesuaikan halaman deskripsi mereka seperti Halaman Web.
3. Jika pengguna tidak memilih gambar apa pun sebagai banner di FilePicker "**Banner Image**", "**Project Execution Page**" akan menggunakan warna latar belakang tema default sebagai banner.
4. Kotak teks "**Name**" yang akan digunakan sebagai nama proyek memiliki batasan karakter hingga 300 karakter, sehingga pengguna tidak dapat mengetik lebih dari itu.


