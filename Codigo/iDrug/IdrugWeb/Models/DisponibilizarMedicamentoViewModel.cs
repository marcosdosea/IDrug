using Core;

namespace IdrugWeb.Models
{
    public class DisponibilizarMedicamentoViewModel
    {
        
        public List<DisponibilizarMedicamentoModel> listaDisponibilizacaoMedicamentosModel;
        public IEnumerable<Medicamento> listaMedicamento;

        public DisponibilizarMedicamentoViewModel(List<DisponibilizarMedicamentoModel> listaDisponibilizacaoMedicamentosModel, IEnumerable<Medicamento> listaMedicamento)
        {
            this.listaDisponibilizacaoMedicamentosModel = listaDisponibilizacaoMedicamentosModel;
            this.listaMedicamento = listaMedicamento;
        }
    }
}
