﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GostMVC.ApartmaniCRUDServis {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ApartmaniCRUDServis.IApartmaniCRUDService")]
    public interface IApartmaniCRUDService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/dohvatiListuApartmana", ReplyAction="http://tempuri.org/IApartmaniCRUDService/dohvatiListuApartmanaResponse")]
        ApartmaniService.DTO.ApartmanDTO[] dohvatiListuApartmana();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/dohvatiListuApartmana", ReplyAction="http://tempuri.org/IApartmaniCRUDService/dohvatiListuApartmanaResponse")]
        System.Threading.Tasks.Task<ApartmaniService.DTO.ApartmanDTO[]> dohvatiListuApartmanaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/kreirajNoviApartman", ReplyAction="http://tempuri.org/IApartmaniCRUDService/kreirajNoviApartmanResponse")]
        bool kreirajNoviApartman(ApartmaniService.DTO.ApartmanDTO noviApartman);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/kreirajNoviApartman", ReplyAction="http://tempuri.org/IApartmaniCRUDService/kreirajNoviApartmanResponse")]
        System.Threading.Tasks.Task<bool> kreirajNoviApartmanAsync(ApartmaniService.DTO.ApartmanDTO noviApartman);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/dohvatiApartmanID", ReplyAction="http://tempuri.org/IApartmaniCRUDService/dohvatiApartmanIDResponse")]
        ApartmaniService.DTO.ApartmanDTO dohvatiApartmanID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/dohvatiApartmanID", ReplyAction="http://tempuri.org/IApartmaniCRUDService/dohvatiApartmanIDResponse")]
        System.Threading.Tasks.Task<ApartmaniService.DTO.ApartmanDTO> dohvatiApartmanIDAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/urediApartman", ReplyAction="http://tempuri.org/IApartmaniCRUDService/urediApartmanResponse")]
        bool urediApartman(ApartmaniService.DTO.ApartmanDTO apartman);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IApartmaniCRUDService/urediApartman", ReplyAction="http://tempuri.org/IApartmaniCRUDService/urediApartmanResponse")]
        System.Threading.Tasks.Task<bool> urediApartmanAsync(ApartmaniService.DTO.ApartmanDTO apartman);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IApartmaniCRUDServiceChannel : GostMVC.ApartmaniCRUDServis.IApartmaniCRUDService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ApartmaniCRUDServiceClient : System.ServiceModel.ClientBase<GostMVC.ApartmaniCRUDServis.IApartmaniCRUDService>, GostMVC.ApartmaniCRUDServis.IApartmaniCRUDService {
        
        public ApartmaniCRUDServiceClient() {
        }
        
        public ApartmaniCRUDServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ApartmaniCRUDServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ApartmaniCRUDServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ApartmaniCRUDServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ApartmaniService.DTO.ApartmanDTO[] dohvatiListuApartmana() {
            return base.Channel.dohvatiListuApartmana();
        }
        
        public System.Threading.Tasks.Task<ApartmaniService.DTO.ApartmanDTO[]> dohvatiListuApartmanaAsync() {
            return base.Channel.dohvatiListuApartmanaAsync();
        }
        
        public bool kreirajNoviApartman(ApartmaniService.DTO.ApartmanDTO noviApartman) {
            return base.Channel.kreirajNoviApartman(noviApartman);
        }
        
        public System.Threading.Tasks.Task<bool> kreirajNoviApartmanAsync(ApartmaniService.DTO.ApartmanDTO noviApartman) {
            return base.Channel.kreirajNoviApartmanAsync(noviApartman);
        }
        
        public ApartmaniService.DTO.ApartmanDTO dohvatiApartmanID(int id) {
            return base.Channel.dohvatiApartmanID(id);
        }
        
        public System.Threading.Tasks.Task<ApartmaniService.DTO.ApartmanDTO> dohvatiApartmanIDAsync(int id) {
            return base.Channel.dohvatiApartmanIDAsync(id);
        }
        
        public bool urediApartman(ApartmaniService.DTO.ApartmanDTO apartman) {
            return base.Channel.urediApartman(apartman);
        }
        
        public System.Threading.Tasks.Task<bool> urediApartmanAsync(ApartmaniService.DTO.ApartmanDTO apartman) {
            return base.Channel.urediApartmanAsync(apartman);
        }
    }
}