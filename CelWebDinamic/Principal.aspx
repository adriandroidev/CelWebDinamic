<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="CelWebDinamic.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <link href="asset/css/Principal.css" rel="stylesheet" />

   <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div class="row">

        <asp:Panel runat="server" ID="panelAdministracionUsuarios" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkAdministracionUsuarios" OnClick="lnkAdministracionUsuarios_Click">
            <div class="card flex-column" style="background-color:rgb(1 145 188);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-magnifying-glass icono" ></i>
                           
                            
                            
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Administracion Usuarios <br /> CelWeb</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelFormulario_2" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_2" OnClick="lnkFormulario_2_Click">
            <div class="card flex-column" style="background-color:rgb(1 145 188);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-user icono" ></i>
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Clientes <br /> CelWeb</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelFormulario_3" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_3" OnClick="lnkFormulario_3_Click">
            <div class="card flex-column" style="background-color:rgb(1 145 188);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-print icono" ></i>
                            
                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Facturas <br /> CelWeb</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel runat="server" ID="panelFormulario_4" CssClass="col-md-3 CardMenuPrincipal" Visible="true">
            <asp:LinkButton runat="server" ID="lnkFormulario_4" OnClick="lnkFormulario_4_Click">
            <div class="card flex-column" style="background-color:rgb(1 145 188);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-paper-plane icono" ></i>
                            

                        </div>
                        <div class="col-sm-8 tituloCard">
                            <h4>Envios <br /> CelWeb</h4>
                        </div>
                    </div>
                </div>
            </div>
            </asp:LinkButton>
        </asp:Panel>

    </div>
         </ContentTemplate>
      </asp:UpdatePanel>

</asp:Content>
