/*==============================================================*/
/* Nom de SGBD :  Microsoft SQL Server 2008                     */
/* Date de création :  15/10/2019 15:30:45                      */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Document') and o.name = 'FK_DOCUMENT_LIER_EVENEMEN')
alter table Document
   drop constraint FK_DOCUMENT_LIER_EVENEMEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Document') and o.name = 'FK_DOCUMENT_RENOUVELE_DOCUMENT')
alter table Document
   drop constraint FK_DOCUMENT_RENOUVELE_DOCUMENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Evenement') and o.name = 'FK_EVENEMEN_ASSOCIER_TYPEEVEN')
alter table Evenement
   drop constraint FK_EVENEMEN_ASSOCIER_TYPEEVEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Membre') and o.name = 'FK_MEMBRE_RATTACHER_MEMBRE')
alter table Membre
   drop constraint FK_MEMBRE_RATTACHER_MEMBRE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TypeDocument') and o.name = 'FK_TYPEDOCU_POSSEDER_DOCUMENT')
alter table TypeDocument
   drop constraint FK_TYPEDOCU_POSSEDER_DOCUMENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('obtenir') and o.name = 'FK_OBTENIR_OBTENIR_DOCUMENT')
alter table obtenir
   drop constraint FK_OBTENIR_OBTENIR_DOCUMENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('obtenir') and o.name = 'FK_OBTENIR_OBTENIR_MEMBRE')
alter table obtenir
   drop constraint FK_OBTENIR_OBTENIR_MEMBRE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('programmer') and o.name = 'FK_PROGRAMM_PROGRAMME_EVENEMEN')
alter table programmer
   drop constraint FK_PROGRAMM_PROGRAMME_EVENEMEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('programmer') and o.name = 'FK_PROGRAMM_PROGRAMME_MEMBRE')
alter table programmer
   drop constraint FK_PROGRAMM_PROGRAMME_MEMBRE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Document')
            and   name  = 'LIER_FK'
            and   indid > 0
            and   indid < 255)
   drop index Document.LIER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Document')
            and   type = 'U')
   drop table Document
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Evenement')
            and   name  = 'ASSOCIER_FK'
            and   indid > 0
            and   indid < 255)
   drop index Evenement.ASSOCIER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Evenement')
            and   type = 'U')
   drop table Evenement
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Membre')
            and   name  = 'RATTACHER_FK'
            and   indid > 0
            and   indid < 255)
   drop index Membre.RATTACHER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Membre')
            and   type = 'U')
   drop table Membre
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TypeDocument')
            and   name  = 'POSSEDER_FK'
            and   indid > 0
            and   indid < 255)
   drop index TypeDocument.POSSEDER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TypeDocument')
            and   type = 'U')
   drop table TypeDocument
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TypeEvenement')
            and   type = 'U')
   drop table TypeEvenement
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('obtenir')
            and   name  = 'OBTENIR_FK'
            and   indid > 0
            and   indid < 255)
   drop index obtenir.OBTENIR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('obtenir')
            and   type = 'U')
   drop table obtenir
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('programmer')
            and   name  = 'PROGRAMMER_FK'
            and   indid > 0
            and   indid < 255)
   drop index programmer.PROGRAMMER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('programmer')
            and   type = 'U')
   drop table programmer
go

/*==============================================================*/
/* Table : Document                                             */
/*==============================================================*/
create table Document (
   id                   int                  not null,
   Doc_id               int                  null,
   nom                  varchar(50)          not null,
   code                 varchar(50)          not null,
   periodicite          bit                  null,
   description          varchar(254)         null,
   dateEts              datetime             null,
   dateExp              datetime             null,
   organisme            varchar(70)          null,
   dateEnr              datetime             null,
   dateDerModif         datetime             null,
   typeEnr              varchar(50)          null,
   photo                tinyint              null,
   fichier              tinyint              null,
   constraint PK_DOCUMENT primary key (id)
)
go

/*==============================================================*/
/* Index : LIER_FK                                              */
/*==============================================================*/
create index LIER_FK on Document (
id ASC
)
go

/*==============================================================*/
/* Table : Evenement                                            */
/*==============================================================*/
create table Evenement (
   id                   int                  not null,
   nom                  varchar(50)          not null,
   periodicite          varchar(30)          null,
   dateDeb              datetime             null,
   dateFin              datetime             null,
   description          varchar(254)         null,
   traite               bit                  null,
   dateEnr              datetime             null,
   dateDerModif         datetime             null,
   typeEnr              varchar(50)          null,
   photo                tinyint              null,
   fichier              tinyint              null,
   constraint PK_EVENEMENT primary key (id)
)
go

/*==============================================================*/
/* Index : ASSOCIER_FK                                          */
/*==============================================================*/
create index ASSOCIER_FK on Evenement (
id ASC
)
go

/*==============================================================*/
/* Table : Membre                                               */
/*==============================================================*/
create table Membre (
   id                   int                  not null,
   Mem_id               int                  null,
   nom                  varchar(30)          not null,
   prenom               varchar(50)          not null,
   dateNaiss            datetime             not null,
   sexe                 char(1)              null,
   lieuNaiss            varchar(70)          null,
   profession           varchar(70)          null,
   nomPere              varchar(80)          null,
   nomMere              varchar(80)          null,
   groupeSanguin        varchar(2)           null,
   telephone            varchar(30)          null,
   adresse              varchar(70)          null,
   nationalite          varchar(50)          null,
   personnePrevenir     bit                  null,
   login                varchar(30)          null,
   pass                 varchar(30)          null,
   questionPiege        varchar(100)         null,
   reponse              varchar(100)         null,
   principal            bit                  null,
   lien                 varchar(50)          null,
   dateEnr              datetime             null,
   dateDerModif         datetime             null,
   typeEnr              varchar(50)          null,
   photo                tinyint              null,
   fichier              tinyint              null,
   constraint PK_MEMBRE primary key (id)
)
go

/*==============================================================*/
/* Index : RATTACHER_FK                                         */
/*==============================================================*/
create index RATTACHER_FK on Membre (
Mem_id ASC
)
go

/*==============================================================*/
/* Table : TypeDocument                                         */
/*==============================================================*/
create table TypeDocument (
   id                   int                  not null,
   nom                  varchar(30)          not null,
   description          varchar(254)         null,
   dateEnr              datetime             null,
   dateDerModif         datetime             null,
   typeEnr              varchar(50)          null,
   photo                tinyint              null,
   fichier              tinyint              null,
   constraint PK_TYPEDOCUMENT primary key (id)
)
go

/*==============================================================*/
/* Index : POSSEDER_FK                                          */
/*==============================================================*/
create index POSSEDER_FK on TypeDocument (
id ASC
)
go

/*==============================================================*/
/* Table : TypeEvenement                                        */
/*==============================================================*/
create table TypeEvenement (
   id                   int                  not null,
   nom                  varchar(30)          not null,
   description          varchar(254)         null,
   dateEnr              datetime             null,
   dateDerModif         datetime             null,
   typeEnr              varchar(50)          null,
   photo                tinyint              null,
   fichier              tinyint              null,
   constraint PK_TYPEEVENEMENT primary key (id)
)
go

/*==============================================================*/
/* Table : obtenir                                              */
/*==============================================================*/
create table obtenir (
   id                   int                  null,
   Doc_id               int                  null
)
go

/*==============================================================*/
/* Index : OBTENIR_FK                                           */
/*==============================================================*/
create index OBTENIR_FK on obtenir (
Doc_id ASC
)
go

/*==============================================================*/
/* Table : programmer                                           */
/*==============================================================*/
create table programmer (
   id                   int                  null,
   Eve_id               int                  null
)
go

/*==============================================================*/
/* Index : PROGRAMMER_FK                                        */
/*==============================================================*/
create index PROGRAMMER_FK on programmer (
id ASC
)
go

alter table Document
   add constraint FK_DOCUMENT_LIER_EVENEMEN foreign key (id)
      references Evenement (id)
go

alter table Document
   add constraint FK_DOCUMENT_RENOUVELE_DOCUMENT foreign key (Doc_id)
      references Document (id)
go

alter table Evenement
   add constraint FK_EVENEMEN_ASSOCIER_TYPEEVEN foreign key (id)
      references TypeEvenement (id)
go

alter table Membre
   add constraint FK_MEMBRE_RATTACHER_MEMBRE foreign key (Mem_id)
      references Membre (id)
go

alter table TypeDocument
   add constraint FK_TYPEDOCU_POSSEDER_DOCUMENT foreign key (id)
      references Document (id)
go

alter table obtenir
   add constraint FK_OBTENIR_OBTENIR_DOCUMENT foreign key (Doc_id)
      references Document (id)
go

alter table obtenir
   add constraint FK_OBTENIR_OBTENIR_MEMBRE foreign key (id)
      references Membre (id)
go

alter table programmer
   add constraint FK_PROGRAMM_PROGRAMME_EVENEMEN foreign key (Eve_id)
      references Evenement (id)
go

alter table programmer
   add constraint FK_PROGRAMM_PROGRAMME_MEMBRE foreign key (id)
      references Membre (id)
go

