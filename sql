create database YuzTanima;
go
use YuzTanima;
go
create table Kameralar(
kameraId int identity(1,1) primary key,
kullaniciAdi nvarchar(200),
sifre nvarchar(200),
ip nvarchar(100),
isim nvarchar(200),
uzanti nvarchar(200),
protokol nvarchar(200) )
go
create table Birimler(
birimId int identity(1,1) primary key,
birimAdi nvarchar(200)
)
go
create table Calisanlar(
calisanId int identity(1,1) primary key,
calisanAd nvarchar(200),
calisanSoyad nvarchar(200),
birimId int foreign key references Birimler(birimId),
resimUrl nvarchar(200))
go
create table Ziyaretciler(
ziyaretciId int identity(1,1) primary key,
ad nvarchar(200),
soyad nvarchar(200),
adres nvarchar(500),
telefon nvarchar(15),
resimUrl nvarchar(200),
calisanId int foreign key references Calisanlar(calisanId))
go
create table CalisanKameralari(
calisanKameralariId int identity(1,1) primary key,
calisanId int foreign key references Calisanlar(calisanId),
kameraId int foreign key references Kameralar(kameraId))
go
create table KayitliZiyaretciler(
kayitliZiyaretciId int identity(1,1) primary key,
ziyaretci nvarchar(400),
kameraId int foreign key references Kameralar(kameraId),
zaman DateTime)
go
create table KayitliOlmayanZiyaretciler(
kayitliOlmayanZiyaretciId int identity(1,1) primary key,
ziyaretci nvarchar(400),
kameraId int foreign key references Kameralar(kameraId),
zaman DateTime)
go
create table CalisanYollari(
calisanYollariId int identity(1,1) primary key,
calisanId int foreign key references Calisanlar(calisanId),
kameraId int foreign key references Kameralar(kameraId),
siraNo int)
go
create table RaporTipleri(
tipId int identity(1,1) primary key,
tipAdi nvarchar(100))
go
create table Raporlar(
raporId int identity(1,1) primary key,
tipId int foreign key references RaporTipleri(tipId),
mesaj nvarchar(500))
